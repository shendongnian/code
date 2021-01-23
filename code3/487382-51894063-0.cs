        [Fact]
        public void RetrievingACustomer_ShouldReturnTheExpectedCustomer()
        {
          // Arrange
          var expectedCustomer = new Customer
          {
            FirstName = "Silence",
            LastName = "Dogood",
            Address = new Address
            {
              AddressLineOne = "The New-England Courant",
              AddressLineTwo = "3 Queen Street",
              City = "Boston",
              State = "MA",
              PostalCode = "02114"
            }                                            
          }.ToExpectedObject();
    
      
          // Act
          var actualCustomer = new CustomerService().GetCustomerByName("Silence", "Dogood");
    
          // Assert
          expectedCustomer.ShouldEqual(actualCustomer);
        }
