    Person p = new Person { Firstname = "Jason", LastName = "Argonauts" };
    Person p2 = new Person { Firstname = "Jason", LastName = "Argonaut" };
    //assuming you have already created a class person!
    string personString = p.Serialize();
    string person2String = p2.Serialize();
