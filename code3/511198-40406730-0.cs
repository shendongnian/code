    [TestMethod,Isolated]
        public void TestMethod1()
        {
            var mock = Isolate.Fake.Instance<EmailService>();
            Isolate.WhenCalled(() => mock.SendEmail()).WillReturn(true);
            var cust = new Customer();
            var result = cust.AddCustomer(mock);
            Assert.IsTrue(result);
        }
