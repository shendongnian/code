    public class MyEndClass
    {
        private readonly IDependency dependency;
        public MyEndClass(IDependency dependency)
        {
            this.dependency = dependency;
        }
        // temporary constructor until we introduce IoC
        public MyEndClass() : this(new Dependency())
        {
        }
    }
