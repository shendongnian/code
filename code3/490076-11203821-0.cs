        [TestInitialize]
        public void Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<Guid>().Use(c => { return Guid.NewGuid(); });
            });
        }
        [TestMethod]
        public void Test()
        {
            var o1 = ObjectFactory.GetInstance<Guid>();
            var o2 = ObjectFactory.GetInstance<Guid>();
            Assert.AreNotSame(o1, o2);
        }
