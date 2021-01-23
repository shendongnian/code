    public class Service
    {
        public void SomeOperation() {
            IDependency dependency = 
                ServiceLocator.GetInstance<IDependency>();
            dependency.Execute();
        }
    }
