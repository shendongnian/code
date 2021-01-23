    using System.Diagnostics;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    namespace ConsoleApplication2
    {
        public class SomeViewModel
        {
            public SomeViewModel(ISomeFactory factory)
            {
                var dependency1 = factory.CreateSomeDependency();
                var dependency2 = factory.CreateSomeDependency();
                Debug.Assert(dependency1 != dependency2);
                Debug.Assert(dependency1.Dep == dependency2.Dep);
            }
        }
        public class SomeDependency
        {
            private readonly DepDep _dep;
            public SomeDependency(DepDep dep)
            {
                _dep = dep;
            }
            public DepDep Dep
            {
                get { return _dep; }
            }
        }
        public class DepDep
        {
        }
        public interface ISomeFactory
        {
            SomeDependency CreateSomeDependency();
        }
        class Program
        {
            static void Main(string[] args)
            {
                var container = new WindsorContainer();
                container.AddFacility<TypedFactoryFacility>();
                container.Register(
                    Component.For<SomeViewModel>().LifestyleTransient(),
                    Component.For<SomeDependency>().LifestyleTransient(),
                    Component.For<DepDep>().LifestyleBoundTo<SomeViewModel>(),
                    Component.For<ISomeFactory>().AsFactory().LifestyleTransient()
                    );
                container.Resolve<SomeViewModel>();
            }
        }
    }
