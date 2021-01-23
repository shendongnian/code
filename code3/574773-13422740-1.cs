    public class A
    {
        private List<IDependency2> _things;
    
        public A(IDependency1 obj1, IDependencyFactory<IDependency2> dep2Factory)
        {
            _things = new List<IDependency2>();
            foreach (var x in someCollection)
                _things.Add(dep2Factory.Create());
    
        }
    }
