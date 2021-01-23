    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Initialize_should_get_called_on_object_construction()
        {
            var container = new UnityContainer();
            container.RegisterType<IDependency, Dependency>(
                new InjectionMethod("Initialize" /*, parameters if present */)
            );
            var dependency = container.Resolve<IDependency>();
            Assert.IsNotNull(dependency);
            Assert.AreEqual("init", dependency.Value);
        }
    }
    public interface IDependency
    {
        string Value { get; set; }
        void Initialize();
    }
    public class Dependency : IDependency 
    {
        public string Value { get; set; }
        public void Initialize() {
            this.Value = "init";
        }
    }
