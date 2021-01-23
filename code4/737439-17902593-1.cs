    // First scenario look up for some book that really exists 
    var bookThatExists = library.GetByID(3);
    Assert.IsNotNull(bookThatExists);
    Assert.AreEqual(bookThatExists.Id, 3);
    Assert.AreEqual(bookThatExists.Name, "Book3");
    // Second scenario look for some book that does not exist 
    //(I don't have any book in my memory database with Id = 5 
    Assert.That(() => library.GetByID(5),
                       Throws.Exception
                             .TypeOf<InvalidOperationException>());
    // Add more test case depending on your business context
    .....
