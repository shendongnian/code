        public class FactoryClass
        {        
            public ClassWithLotsOfRepositories GetClassWithLotsOfRepositories()
            {
                return new ClassWithLotsOfRepositories(new repository1(), 
                              new repository2(), new repository3() );
            }
        }
