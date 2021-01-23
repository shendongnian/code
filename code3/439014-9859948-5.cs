    public class Service
    {
        private readonly IDependency dependency;
        public Service(IDependency dependency)&#xD;{
            this.dependency = dependency;
        }
        public void SomeOperation()&#xD;{
            this.dependency.Execute();
        }
    }
