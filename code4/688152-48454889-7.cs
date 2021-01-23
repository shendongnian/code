    [TestMethod]
    public void GetTyreSpecification_test() {
        //Arrange
        var vehicleIdentifier = 123456;
        var expected = new Tyre { NumberOfTyres = 4, TyreSize = 18 };
        var mockSystem = new Mock<IExternalManufactureSystem>();
        mockSystem.Setup(s => s.GetTyreSpecification(vehicleIdentifier)).Returns(expected);
        var selecter = new Selecter(null, mockSystem.Object);
        //Act
        var actual = selecter.GetTyreSpecification(vehicleIdentifier);
        //Assert
        Assert.AreEqual(expected, actual);
    }
