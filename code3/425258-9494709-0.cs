        [TestMethod]
        public void TestMethod1()
        {
            ITestInterface mockProxy = MockRepository.GenerateMock<ITestInterface>();
            TestClass tc = new TestClass(mockProxy);
            bool result = tc.Method1(5);           
            Assert.IsTrue(result);
            mockProxy.AssertWasCalled(x => x.Method1(5));
        }
