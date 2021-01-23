    namespace ... {
        // ... other code here...
        public class Factory {
            public Product1<T> Create<T>() where T : S1 {
                return new Product1<T>();
            }
            public Product2<T> Create<T>() where T : S2 {
                return new Product2<T>();
            }
        }
    
        class Program {
            static void Main(string[] args) {
                Factory f = new Factory();
                ProductBase s = f.Create<S1Concrete>();
            }
        }
    }
