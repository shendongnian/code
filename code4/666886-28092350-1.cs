    public class TestBase
    {
        private static bool _isInitialized = false;
        private object _locker = new object();
        public TestBase()
        {
            lock (_locker) 
            {
              if (!_isInitialized)
              {
                TestClassInitialize();
                _isInitialized = true;
              }
            }
        }
        public void TestClassInitialize()
        {
            // Do one-time init stuff
        }
    }
    public class SalesOrderTotals_Test : TestBase
    {
        [TestMethod]
        public void TotalsCalulateWhenThereIsNoSalesTax()
        {
        }
        [TestMethod]
        public void TotalsCalulateWhenThereIsSalesTax()
        {
        }
    }
