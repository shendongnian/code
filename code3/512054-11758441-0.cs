    [TestMethod]
    public void TestRetire()
    {
        using (TransactionScope transaction = new TransactionScope())
        {
            Assert.IsTrue(Car.Retire("VLV100"));
            Assert.IsFalse(Car.Retire("VLV100"));
     
            // Deliberately not commiting transaction.
        }
    }
