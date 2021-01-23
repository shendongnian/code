    List<string> myCollection = new List<string>()
    {
        "Bob", "Bob","Alex", "Abdi", "Abdi", "Bob", "Alex", "Bob","Abdi"
    };
    myCollection.Sort();
    foreach (var name in myCollection.Distinct())
    {
        Console.WriteLine(name + " " + myCollection.Count(x=> x == name));
    }
