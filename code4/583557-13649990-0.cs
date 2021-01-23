    public List<Person> SearchPeople(string searchString)
    {
        if (searchString == null || string.IsNullOrEmpty(searchString.Trim()))
            return base._objectSet.ToList();
    
        string[] SearchWords = searchString.Split(',').Select(s => s.Trim()).ToArray();
    
        return (from    person 
                in      base._objectSet 
                let     t = (getProperties(person)) 
                where   SearchWords.All(word => t.Contains(word)) 
                select  person).ToList();
    }
