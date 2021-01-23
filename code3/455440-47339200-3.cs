            [Test]
        public void TestDependencyInjection()
        {
            var ferrari = CarFactoryKernel.Instance.GetCarFromFactory("Ferrari");
            Assert.That(ferrari, Is.Not.Null);
            Assert.That(ferrari, Is.Not.Null.And.InstanceOf(typeof(Ferrari)));
            Assert.AreEqual("Drive the Ferrari forward!", ferrari.Drive);
            Assert.AreEqual("Drive the Ferrari backward!", ferrari.Reverse);
            var lambo = CarFactoryKernel.Instance.GetCarFromFactory("Lamborghini");
            Assert.That(lambo, Is.Not.Null);
            Assert.That(lambo, Is.Not.Null.And.InstanceOf(typeof(Lamborghini)));
            Assert.AreEqual("Drive the Lamborghini forward!", lambo.Drive);
            Assert.AreEqual("Drive the Lamborghini backward!", lambo.Reverse);
        }
