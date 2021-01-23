    public interface IApple { string GetName(); }
    public interface IBanana { string GetName(); }
    
    internal interface IFruit { string GetName(); }
    class FruitAdaptor: IFruit
    {
        public NameAdaptor(string name) { this.name = name; }
        private string name;
        public string GetName() { return name; }
    }
    // convenience methods for fruit:
    static class IFruitExtensions
    {
        public static IFruit AsFruit(this IBanana banana)
        {
            return new FruitAdaptor(banana.GetName());
        }
        public static IFruit AsFruit(this IApple apple)
        {
            return new FruitAdaptor(apple.GetName());
        }
    }
