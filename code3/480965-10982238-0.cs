        [TestMethod]
        public void ThatObjectFactoryReturnsDifferentTypesFromTwoThreadsWhenConfiguredThreadLocalStorage()
        {
            ObjectFactory.Configure(x => x.For<ITestObjectFactory>().LifecycleIs(new ThreadLocalStorageLifecycle()).Use<Test>());
            var test1 = ObjectFactory.GetInstance<ITestObjectFactory>();
            var t = new Thread(ConfigureThreadLocalStorageTest1);
            t.Start();
            t.Join();
            var test2 = ObjectFactory.GetInstance<ITestObjectFactory>();
            Assert.AreSame(test1, test2);
            Assert.AreNotSame(test1, _staticTest);
        }
        static void ConfigureThreadLocalStorageTest1()
        {
            System.Diagnostics.Debug.WriteLine(ObjectFactory.TryGetInstance<ITestObjectFactory>());
            _staticTest = ObjectFactory.GetInstance<ITestObjectFactory>();
        }
        private static ITestObjectFactory _staticTest;
        public class Test : ITestObjectFactory
        {
        }
        public interface ITestObjectFactory
        {
        }
