        abstract class A
        {
            public A (IDependency dependency)
            {
                Dependency = dependency;
            }
            public IDependency Dependency { get; private set; }
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
