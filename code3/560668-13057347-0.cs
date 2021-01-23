    String TID = string.empty;
    
    [TestFixtureSetUp]
    public void Given() {
      //calling webservices and code
      TID = hID;
      //calling webservices and code
    }
    
    [Test]
    public void assertions_call_1() {
       ...
    }
    
    public void assertions_on_call_2() {
       if (string.IsNullOrEmpty(TID))
         Assert.Inconclusive("Prerequisites for test not met");
       ...
    }
