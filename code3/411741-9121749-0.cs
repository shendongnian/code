        [TestMethod]
        public void Verify_All_Bars_Called()
        {
            var myBarList = new List<Bar>() { new Bar(), new Bar() };
            var myStub = new Mock<IBarRepository>();
            myStub.Setup(repos => repos.GetBarsFromStore()).Returns(myBarList);
            var myService = new FooService(myStub.Object);
            Assert.AreEqual<int>(myBarList.Count, myService.GetBars().Count);
        }
