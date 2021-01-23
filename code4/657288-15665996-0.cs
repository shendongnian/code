        private Thread _thread;
        private AutoResetEvent _resetEvent;
        [SetUp]
        public void SetUp()
        {
            _thread = new Thread(Run);
            _resetEvent = new AutoResetEvent(false);
        }
        [Test]
        public void GetResults_ReturnsDataInReasonableAmountOfTime_Test()
        {
            _thread.Start();
            Assert.IsTrue(_resetEvent.WaitOne(2000));
        }
        private void Run()
        {
            // your long method call
            _resetEvent.Set();
        }
