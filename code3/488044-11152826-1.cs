    [Test]
    public void TestGettingCustomersRefreshesViewModel()
    {
        //arrange
        var mockDb = new Mock<IDataLayer>();
        mockDb.Setup(db => db.GetAllCustomers()).Returns(new List<Customer>());
        underTest.DataRepository = mockDb.Object;
    
        //act
        underTest.GetCustomerCommand.Execute();
    
        //assert
        Assert.That(underTest.CustomerList != null);
    }
