    abstract class Factory 
        {
            public abstract Product GetProduct(); //Factory Method Declaration
        }
    
    class concreteFactoryforProcuct1 : Factory
        {
            public override Product GetProduct() //Factory Method Implementation
                {
                    return new Product1();
                }
        }
