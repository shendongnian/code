    public class Factory
    {
        public ProductBase Create<T>(string name)
        {
            Type type;
            switch (name)
            {
                case "P1":
                    type = typeof (Product1<>);
                    break;
                case "P2":
                    type = typeof (Product2<>);
                    break;
                case "P3":
                    type = typeof (Product3<>);
                    break;
                default:
                    return null;
            }
            type = type.MakeGenericType(typeof (T));
            return (ProductBase) Activator.CreateInstance(type);
        }
    }
