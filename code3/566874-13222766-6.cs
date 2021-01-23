        abstract class A
        {
            public IDependency Dependency { get; private set; }
            public A (IDependency dependency)
            {
                Dependency = dependency;
            }
        }
        class B : A
        {
            public B (IDependency dependency)
                : base(dependency)
            {
            }
        }
        class C : A
        {
            public C (IDependency dependency)
                : base(dependency)
            {
            }
        }
        interface IDependency { }
        class EmptyDependency : IDependency { }
        class ConcreteDependency : IDependency { }
