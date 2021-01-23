    public interface IFruit
    {
        decimal GetWeight();
    }
    public class Fruit : IFruit
    {
        protected decimal Weight;
        public string Name { get; set; }
        public decimal GetWeight()
        {
            return Weight;
        }
    }
    public class Apple : Fruit
    {
        public Apple()
        {
            Name = "Granny Smith";
            Weight = (decimal) 2.1;
        }
    }
    public class Banana : Fruit
    {
        public Banana()
        {
            Name = "Cavendish";
            Weight = (decimal) 1.5;
        }
    }
    public enum FruitType
    {
        Banana,
        Apple
    }
    public static class FruitFactory
    {
        public static IFruit CreateFruit(FruitType f)
        {
            switch(f)
            {
                case FruitType.Banana: return new Banana();
                case FruitType.Apple: return new Apple();
                default: return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var apple = FruitFactory.CreateFruit(FruitType.Apple);
            var banana = FruitFactory.CreateFruit(FruitType.Banana);
            Console.WriteLine(apple.GetWeight());
            Console.WriteLine(banana.GetWeight());
        }
    }
