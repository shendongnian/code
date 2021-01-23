    var person = new Person();
    person.HairColor = "Blonde";
    // this will emit "True" to the console...
    if (person.HairColor == "Blonde")
    {
        Console.WriteLine(true);
    }
    else
    {
        Console.WriteLine(false);
    }
    // update the info per your logic...
    person.HairColor.Update();
    // you can change the hair color and update again, LOL
    person.HairColor = "Brown";
    person.HairColor.Update();
