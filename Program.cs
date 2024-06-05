using System;

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public virtual decimal ValorEmEstoque()
    {
        return Preco * Quantidade;
    }
}

public class ProdutoPerecivel : Produto
{
    public DateTime DataDeValidade { get; set; }

    public override decimal ValorEmEstoque()
    {
        // Verifica se a data de validade está próxima
        if (DataDeValidade <= DateTime.Today)
        {
            return base.ValorEmEstoque() * 0.8m; // Aplica desconto de 20%
        }
        else
        {
            return base.ValorEmEstoque();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Exemplo de uso
        ProdutoPerecivel produto1 = new ProdutoPerecivel
        {
            Nome = "Leite",
            Preco = 3.5m,
            Quantidade = 10,
            DataDeValidade = new DateTime(2024, 6, 1)
        };

        ProdutoPerecivel produto2 = new ProdutoPerecivel
        {
            Nome = "Pão",
            Preco = 2.0m,
            Quantidade = 20,
            DataDeValidade = new DateTime(2024, 7, 1)
        };

        Console.WriteLine("Valor do estoque do produto 1: " + produto1.ValorEmEstoque());
        Console.WriteLine("Valor do estoque do produto 2: " + produto2.ValorEmEstoque());
    }
}

//Neste código, a classe ProdutoPerecivel herda da classe Produto. Assim como em Python, isso significa que ProdutoPerecivel possui todos os atributos e métodos de Produto, além dos seus próprios. A palavra-chave override é usada para substituir o método ValorEmEstoque da classe base (Produto), permitindo que ProdutoPerecivel adicione a lógica de desconto para produtos perecíveis.

//Portanto, a herança em C# é semelhante ao conceito em Python, permitindo a extensão de funcionalidades de classes existentes.