    public interface IProductFactory
    {
        IProduct MakeProduct(Condition condition);
    }
    internal class ProductFactory : IProductFactory
    {
        public IProduct MakeProduct(Condition condition)
        {
            IProduct product;
            switch (condition)
            {
                case Condition.CaseA:
                    product = new ProductA();
                    // Other product setup code
                    break;
                case Condition.CaseA2:
                    product = new ProductA();
                    // Yet other product setup code
                    break;
                case Condition.CaseB:
                    product = new ProductB();
                    // Other product setup code
                    break;
                default:
                    throw new Exception(string.Format("Condition {0} ...", condition));
            }
            return product;
        }
    }
    public class SomeClient
    {
        private readonly IProductFactory _productFactory;
        public SomeClient(IProductFactory productFactory) // <-- The factory is injected here!
        {
            _productFactory = productFactory;
        }
        // ...
        public void HandleRuntimeData(RuntimeData runtimeData)
        {
            IProduct product = _productFactory.MakeProduct(runtimeData.Condition);
            // use product...
        }
        // ...
    }
    public class RuntimeData
    {
        public Condition Condition { get; set; }
        // ...
    }
    public interface IProduct
    { //...
    }
    internal class ProductB : IProduct
    { //...
    }
    internal class ProductA : IProduct
    { //...
    }
    public enum Condition { CaseA, CaseA2, CaseB }
