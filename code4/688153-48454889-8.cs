    [TestMethod]
    public void GetVehicleByRegistrationNumber_test() {
        //Arrange
        var vehicleIdentifier = 123456;
        var registrationNumber = "ABC123";
        var tyre = new Tyre { TyreSize = 18, NumberOfTyres = 4 };
        var expected = new Vehicle {
            VehicleIdentifier = vehicleIdentifier,
            RegistrationNumber = registrationNumber,
            TyreSpecification = tyre
        };
        var mockSystem = new Mock<IExternalManufactureSystem>();
        mockSystem.Setup(s => s.GetTyreSpecification(vehicleIdentifier)).Returns(tyre);
        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(s => s.GetVehicleByRegistrationNumber(registrationNumber)).Returns(expected);
        var selecter = new Selecter(mockDatabase.Object, mockSystem.Object);
        //Act
        var actual = selecter.GetVehicleByRegistrationNumber(registrationNumber);
        //Assert
        Assert.IsTrue(actual.RegistrationNumber == registrationNumber);
    }    
