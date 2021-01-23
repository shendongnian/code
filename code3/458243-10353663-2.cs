    public Person GetPersonFromDictionary(Dictionary<string,string> dictionary)
    {
        var Person = new Person()
        {
            Name=dictionary[name],
            Age=dictionary[age]
        }
    }
