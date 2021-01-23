        [TestMethod]
        public void MyTestMethod()
        {
            var vs = new VehicleState { passengers = 3 };
            vs.Execute(() => vs.passengers += 1);
            Assert.AreEqual(3, vs.passengers);
            vs.CommitState();
            Assert.AreEqual(4, vs.passengers);
        }
