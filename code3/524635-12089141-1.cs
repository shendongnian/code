    [WebMethod]
    public List<Name> FetchNames(string name)
    {
    //Write your query to get names that begin with the letter passed as parameter
        var emp = new Employee();
        var fetchName = emp.GetNames()
        .Where(m => m.Name.ToLower().StartsWith(name.ToLower()));
        return fetchName.ToList();
    }
