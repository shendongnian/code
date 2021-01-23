    public class MyService
    {
        private readonly ISomeDependency dependency;
        public MyService(ISomeDependency dependency)
        {
            this.dependency = dependency;
        }
    
        public void SomeMethod()
        {
            // do something with the dependency here
        }
    }
