    [Test]
    public void Save_WhenCalled_IsSuccessfull()
    {
        //Arrange
        YourArgsType actualArgs;
        var customerService= new CustomerService();  
        customerService.OnSaved+= (sender, args) =>
                                      {                                           
                                          actualArgs = args;
                                      };
        //Act
        customerService.Save(new Customer{Id=1,Name="Jo");
        //Assert
        Assert.IsTrue(actualArgs.HasSaved);
    }
