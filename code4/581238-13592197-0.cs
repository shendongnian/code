      // arrange
      var expected = new PersonModel
                      {
                         FirstName = "John",
                         LastName = "Doe",
                         DateOfBirth = DateTime.Now
                         // etc
                       }
     
       // act
       var id = InsertModelAndReturnId(expected);
       var actual = RetrieveModelById(id);
    
       // assert
       actual.ShouldHave().AllProperties().EqualTo(expected); // ShouldHave is from Fluent Assertions. This line makes sure expected and actual have the same values after being persisted and retrieved
