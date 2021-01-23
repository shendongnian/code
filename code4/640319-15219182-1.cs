    public class FooProvider : IFooProvider
    {
        private List<IFoo> _allFooServices;
        public FooProvider(IEnumerable<IFoo> fooServices)
        {
            _allFooServices = fooServices.ToList();
        }
    }
