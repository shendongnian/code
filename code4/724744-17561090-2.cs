    Person person = new Person();
    
    int maxLength = StringLength.Get(() => person.Name);
    Console.WriteLine(maxLength); //1000
    maxLength = StringLength.Get(() => person.OtherName);
    Console.WriteLine(maxLength); //-1
