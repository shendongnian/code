    Dictionary<string, int> HeightInInches = new Dictionary<string, int>();
    HeightInInches.Add("Joe", 72);
    HeightInInches.Add("Elaine", 60);
    HeightInInches.Add("Michael", 59);
    foreach(KeyValuePair<string, int> person in HeightInInches)
    {
        Console.WriteLine(person.Key + " is " + person.Value + " inches tall.");
    }
