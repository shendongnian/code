    public class MyClass
    {
        private Func<MyParameter, IDependency1> dependency1Factory;
        private Func<IDependency1, Owned<OwnedDependency>> ownedDependencyFactory;
    
    
        public MyClass(
            Func<MyParameter, IDependency1> dependency1Factory,
            Func<IDependency1, Owned<OwnedDependency>> ownedDependencyFactory)
        {
            this.dependency1Factory = dependency1Factory;
            this.ownedDependencyFactory = ownedDependencyFactory;
        }
    
        public void CreateOwnedDependency()
        {
            var parameter = new MyParameter();
            using (var owned = ownedDependencyFactory(dependency1Factory(parameter)))
            {
            }
    
        }
    }
