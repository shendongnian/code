    [TestMethod]
    public void GetTotalIssuedCountTest()
    {
       // The 5 is exemplary value -
       // you need to determine actual one basing data set contents
       const int expectedIssuedCount = 5;
       var storeRepository = new StoreRepository();
       // Here you'll most likely need to prepare fake data set
       var actualIssuedCount = storeRepository.GetTotalIssuedCount();
       
       Assert.AreEqual(expectedIssuedCount, actualIssuedCount);
    }
