        public class Example
        {
            private readonly Dictionary<Type, IRepository<Base>> _repositoriesCollection =
                new Dictionary<Type, IRepository<Base>>();
            public void DoSomething()
            {
                _repositoriesCollection.Add(typeof(A), new Repository<A>());
            }
        }
        
    
        interface IRepository<out T> where T : Base
        {
            T MakeSomeItem(string info);
            //void AddSomeItem(string info, T itemToAdd); <- this will not 
                                                            // work because T
                                                            // is out - so can't 
                                                            // go in... 
        }
    
        public class Repository<T> : IRepository<T> where T : Base
        {
            public T MakeSomeItem(string info)
            {
                throw new NotImplementedException();
            }
        }
    
        public class Base { }
    
        public class A : Base { }
