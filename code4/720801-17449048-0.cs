    [TestMethod]
    public void GetAgeTest()
    {
        int age = 13;
        Assert.AreEqual(age, GetAge(DateTime.Now.AddYears(age * -1));
    }
