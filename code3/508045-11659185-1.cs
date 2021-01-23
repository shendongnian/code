    Expression<Func<Person, User>> basicUser = person => new User()
    {
        Name = person.FirstName
    };
    var detailedUser = (Expression<Func<Person, User>>)new AddDobBindingVisitor()
        .Visit(basicUser);
    // detailedUser:
    //     person => new User()
    //     {
    //         Name = person.FirstName,
    //         DOB = person.DOB
    //     }
