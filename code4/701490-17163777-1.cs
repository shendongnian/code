        [TestInitialize]
        public void TestInitialize()
        {
            // Get the order number which was added by the TestCleanup method of the previous test
            int orderNumber = (int) UserContext["orderNumber"];
        }
        [TestCleanup]
        public void TestCleanup()
        {
            // When the CreateOrder test is completed, add the order number to the UserContext
            // so the next will have access to it
            UserContext.Add("orderNumber", orderNumber);
        }
