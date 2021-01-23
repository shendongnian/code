    List<string> initList = new List<string> 
    { 
        "ID = 1", 
        "Name = this is a test", 
        "Zip = 5", 
        "ID = 2", 
        "Name = this is a second test", 
        "Zip = 10" 
    };
    
    List<Person> list = new List<Person>();
    Person person = null;
    Type type = typeof(Person);
    foreach (var str in initList)
    {
        var pair = str.Split('=').Select(s => s.Trim()).ToArray();
        if (pair[0] == "ID")
        {
            person = new Person();
            list.Add(person);
        }
        if (person != null)
        {
            PropertyInfo property = type.GetProperty(pair[0]);
            if (property != null)
                property.SetValue(person, pair[1]);
        }
    }
    
    foreach (var item in list)
        Console.WriteLine(item.ID);
    
    Console.ReadLine();
