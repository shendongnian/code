        Person person = new Person
    {
        Name = "Nigal Newborn",
        Age = 1
    };
    
    string jsonIncludeNullValues = JsonConvert.SerializeObject(person, Formatting.Indented);
    
    Console.WriteLine(jsonIncludeNullValues);
    // {
    //   "Name": "Nigal Newborn",
    //   "Age": 1,
    //   "Partner": null,
    //   "Salary": null
    // }
    
    string jsonIgnoreNullValues = JsonConvert.SerializeObject(person, Formatting.Indented, new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    });
    
    Console.WriteLine(jsonIgnoreNullValues);
    // {
    //   "Name": "Nigal Newborn",
    //   "Age": 1
    // }
