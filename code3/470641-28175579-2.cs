    	public TestContext TestContext {get; set;}
        [TestInitialize]
		public void TestInitialise()
		{
            if (TestContext.TestName.IsInitalisedWith("DoSomethingSpecial")
            {
                 // ... Do something special
            }
            else
            {
                 // ... Do something normal
            }
        }
        [TestMethod]
        [InitialiseWith("DoSomethingSpecial")]
        public void MySpecialTest()
        {
             // The test
        }
