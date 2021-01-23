     // declare your mock with strict behavior
	 
	 myClass.Setup(
         x =>
         x.myMethod(
             It.Is<Person>(person => person.Name == "NameA"),
             "Stringb",
             It.Is<Person>(person => person.Name == "NameC"),,
             It.Is<ICollection<string>>(coll =>{ 
					//your other validations
				}),
             It.IsAny<ICollection<string>>(),
             It.IsAny<bool>()));
