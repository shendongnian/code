    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void AddCustomer(bool isCustomerValid)
    {
         //arrange
         //NOTE!!! create the mocks with MockBehavior.Strict
         //that way the test will fail if a call is made w/o setup
    
         const long testCompanyId = 100;
         var testCompany = new Company{ Id = testCompanyId };
         companyRepository.Setup(r => r.GetById(testCompanyId))
              .Returns(testCompany);
         var testCustomer = new Customer
                       {
                            Firstname = "firstName",
                            Surname = "surname",
                            Company = new Company { Id = testCompanyId }
                       };
         customerValidatorMock.Setup(c => c.IsValid(It.Is<Customer>(c => c == testCustomer && c.Company == testCompany)).Returns(isCustomerValid);
         if (isCustomerValid)
         {
              customerRepository.Setup( r => r.AddCustomer(testCustomer) ). Verifiable();
         }
         //act        
         var addCustomerResult = customerServiceSut.AddCustomer(testCustomer);
        
         //assert
         Assert.AreEqual(isCustomerValid, addCustomerResult);
         cutomerRepository.VerifyAll();
    }
