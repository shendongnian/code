    public class TestBase
    {
        private static bool _isInitialized = false;
        public TestBase()
        {
            if (!_isInitialized)
            {
                TestClassInitialize();
                _isInitialized = true;
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
