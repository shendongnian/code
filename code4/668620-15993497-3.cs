    class Person
    {
      ....
      Country CountryOfBirth { get; set; }
      int CountryOfBirthID { get; set; } 
    }
    //then:
    var person = new Person { ... };
    person.CountryOfBirthId = 2;
