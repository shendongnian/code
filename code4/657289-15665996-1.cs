        private AutoResetEvent _resetEvent;
        [TestInitialize]
        public void SetUp()
        {
            _resetEvent = new AutoResetEvent(false);
        }
        [TestMethod]
        public void GetResults_ReturnsDataInReasonableAmountOfTime_Test()
        {
            new Thread(() =>
            {
                // your long method call
                _resetEvent.Set();
            }).Start();
 
            Assert.IsTrue(_resetEvent.WaitOne(2000));
        }
