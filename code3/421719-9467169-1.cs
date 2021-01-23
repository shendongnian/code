        [Test]
        public void Test()
        {
            using (var factory = new ViewFactory())
            {
                var regionOneViews = factory.GetAllViewsInRegion("One");
                Assert.That(regionOneViews, Is.Not.Null);
                Assert.That(regionOneViews, Has.Length.EqualTo(2));
                Assert.That(regionOneViews, Has.Some.TypeOf<RegionOneA>());
                Assert.That(regionOneViews, Has.Some.TypeOf<RegionOneB>());
                var regionTwoViews = factory.GetAllViewsInRegion("Two");
                Assert.That(regionTwoViews, Is.Not.Null);
                Assert.That(regionTwoViews, Has.Length.EqualTo(1));
                Assert.That(regionTwoViews, Has.Some.TypeOf<RegionTwoA>());
            }
        }
    }
    public interface IViewFactory
    {
        IView[] GetAllViewsInRegion(string regionName);
    }
    public class ViewFactory : IViewFactory, IDisposable
    {
        private readonly WindsorContainer _container;
        public ViewFactory()
        {
            _container = new WindsorContainer();
            _container.Register(
                Component.For<IView>().ImplementedBy<RegionOneA>(),
                Component.For<IView>().ImplementedBy<RegionOneB>(),
                Component.For<IView>().ImplementedBy<RegionTwoA>()
                );
        }
        public IView[] GetAllViewsInRegion(string regionName)
        {
            return _container.Kernel.GetHandlers(typeof (IView))
                .Where(h => IsInRegion(h.ComponentModel.Implementation, regionName))
                .Select(h => _container.Kernel.Resolve(h.ComponentModel.Name, typeof (IView)) as IView)
                .ToArray();
        }
        private bool IsInRegion(Type implementation,
                                string regionName)
        {
            var attr =
                implementation.GetCustomAttributes(typeof (RegionAttribute), false).SingleOrDefault() as RegionAttribute;
            return attr != null && attr.Name == regionName;
        }
        public void Dispose()
        {
            _container.Dispose();
        }
    }
    public interface IView {}
    [Region("One")]
    public class RegionOneA : IView {}
    [Region("One")]
    public class RegionOneB : IView {}
    [Region("Two")]
    public class RegionTwoA : IView {}
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RegionAttribute : Attribute
    {
        private readonly string _name;
        public RegionAttribute(string name)
        {
            _name = name;
        }
        public string Name
        {
            get { return _name; }
        }
    }
