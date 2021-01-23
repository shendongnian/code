    [Test]
    public void AddCustomer_CustomerIsValid_ShouldReturnTrue()
    {
        var result = AddCustomerTest(true);
        Assert.IsTrue(result);
    }
    [Test]
    public void AddCustomer_CustomerIsInvalid_ShouldReturnFalse()
    {
        var result = AddCustomerTest(false);
        Assert.IsFalse(result);
    }
    public void AddCustomerTest(bool expectedCustomerValidality)
    {
       //using Moq
        companyRepositoryMock.Setup(c => c.GetById(It.IsAny<int>())).Returns(new Company());          
        customerValidatorMock.Setup(c => c.IsValid(It.IsAny<Customer>())).Returns(expectedCustomerValidality);
        var customer = new Customer
        {
            Firstname = "firstName",
            Surname = "surname",
            Company = new Company { Id = 1 }
        };
        var result= customerServiceSut.AddCustomer(customer);
        return result;
    }
    
