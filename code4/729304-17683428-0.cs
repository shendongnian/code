    internal class Program
    {
        private static void Main(string[] args)
        {
            var bravo = new Bravo();
            var charlie = new Charlie();
            Console.WriteLine(bravo.GetValue());
            Console.WriteLine(charlie.GetValue());
        }
    }
    public abstract class Alpha
    {
        protected static string Value { get; set; }
        public abstract string GetValue();
    }
    public class Bravo : Alpha
    {
        static Bravo()
        {
            Value = "bravo";
        }
        public override string GetValue()
        {
            return Value;
        }
    }
    public class Charlie : Alpha
    {
        static Charlie()
        {
            Value = "charlie";
        }
        public override string GetValue()
        {
            return Value;
        }
    }
