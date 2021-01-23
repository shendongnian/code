    public Person GetPersonFromDictionary(Dictionary<string,string> dictionary)
    {
        var myPerson = new Person()
        {
            Name=dictionary[name],
            Age=dictionary[age]
        }
        return myPerson;
    }
