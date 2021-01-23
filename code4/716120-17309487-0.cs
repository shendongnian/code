    internal class Parent {
        private string Something { get; set; }
    }
    internal class Child : Parent {
        private int SomethingElse { get; set; }
    }
    internal class Program {
        private static void Main(string[] args) {
            Parent reallyChild = new Child();
            Console.WriteLine(reallyChild.GetType().Name);
            Console.ReadLine();
        }
    }
