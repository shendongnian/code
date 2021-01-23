    public static int GetAge(DateTime birthdate, DateTime now)
    {
        // ...
    }
    
    [TestMethod]
    public void GetAgeTest()
    {
        Assert.AreEqual(GetAge(new DateTime(2000, 1, 1), new DateTime(2013, 1, 1)), 13);
    }
