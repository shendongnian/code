        [Test]
        public void TestSpecificBindingToObjectB()
        {
            var kernel = new StandardKernel(new TestModule());
            var b = kernel.Get<B>();
            var c = kernel.Get<C>();
            Assert.AreNotEqual(b.Dependency.GetType(), c.Dependency.GetType());
            Assert.AreEqual(typeof(ConcreteDependency), b.Dependency.GetType());
        }
