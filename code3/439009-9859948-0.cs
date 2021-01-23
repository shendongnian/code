    public class Service
    {
        private readonly IDependency dependency;
        public Service()
        {
            this.dependency = ServiceLocator.GetInstance<IDependency>();
        }
        public void SomeOperation()
        {
            this.dependency.Execute();
        }
    }
