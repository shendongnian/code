        [TestMethod]
        public void DisplayCustomer_ReturnsViewNamed_DisplayCustomer()
        {
            const string expectedViewName = "DisplayCustomer";
            var customer = new Customer();
            var controllerUnderTest = new CustomerController();
            var result = controllerUnderTest.DisplayCustomer(customer);
            Assert.AreEqual(expectedViewName, result.ViewName);
        }
