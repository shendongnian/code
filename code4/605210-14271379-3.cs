    public class Factory
    {
        public ProductBase Create<T>(String Type) where T : IStrategy
        {
            if (Type == "P1")
                return new Product1<T>();
            else if (Type == "P2")
                return new Product2<T>();
            return null;
        }
    };
