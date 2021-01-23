    [TestMethod]
    public void GetAgeTest()
    {
        // Arrange
        int age = 13;
        // Act
        int result = GetAge(DateTime.Now.AddYears(age * -1);
        // Assert
        Assert.AreEqual(age, result);
    }
