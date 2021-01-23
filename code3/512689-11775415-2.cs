    namespace ClassLibrary1
    {
        public class Foo : IProduct
        {
        }
    
        public interface IProduct
        {
        }
    
        public class MyClass
        {
            public List<IProduct> myOriginalProductList = new List<IProduct> { new Foo(), new Foo() };
    
            public void Test(Action<IEnumerable<IProduct>> handler)
            {
                List<IProduct> otherProductList = new List<IProduct> { new Foo(), new Foo() };
                Parallel.ForEach(myOriginalProductList, product =>
                {
                    lock (otherProductList)
                    {
                        if (handler != null)
                        {
                            handler(otherProductList);
                        }
    
                        otherProductList.Add(product);
                    }
                });
            }
        }
    }
