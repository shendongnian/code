    [TestMethod]
    public void GetVehicleByRegistrationNumber_test2() {
        //Arrange
        var vehicleIdentifier = 123456;
        var registrationNumber = "ABC123";
        var tyre = new Tyre { TyreSize = 18, NumberOfTyres = 4 };
        var expected = new Vehicle {
            VehicleIdentifier = vehicleIdentifier,
            RegistrationNumber = registrationNumber,
            TyreSpecification = tyre
        };        
    
        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(s => s.GetVehicleByRegistrationNumber(registrationNumber)).Returns(expected);
    
        var selecter = new Mock<Selecter>(mockDatabase.Object, null) {
            CallBase = true //So that base methods that are not setup can be called.
        }
    
        selecter.Setup(s => s.GetTyreSpecification(vehicleIdentifier)).Returns(tyre);
    
        //Act
        var actual = selecter.Object.GetVehicleByRegistrationNumber(registrationNumber);
    
        //Assert
        Assert.IsTrue(actual.RegistrationNumber == registrationNumber);
    } 
