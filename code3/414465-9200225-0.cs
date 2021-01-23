    var distinctNames = new Dictionary<string, string>();
    foreach(var person in people)
    {
        if(!distinctNames.ContainsKey(person.Name))
        {
            distinctNames.Add(person.Name, person.Name);
        }
    }
