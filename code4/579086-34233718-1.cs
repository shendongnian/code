        [TestMethod]
        public void TestAuth()
        {
            TestMethod1();
        }
        public async void TestMethod1()
        {
            TestLib oLib = new TestLib();
            var bTest = await oLib.Authenticate();
            
        }
