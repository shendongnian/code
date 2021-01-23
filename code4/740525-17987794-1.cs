    public class MyService
    {
        private readonly ISomeDependency dependency;
        public MyService()
        {
            this.dependency = kernel.Get<ISomeDependency>();
        }
    
        public void SomeMethod()
        {
            // do something with the dependency here
        }
    }
