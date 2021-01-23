    // Variant 2: Detecting the type at runtime.
    public void DynamicQueryExample(string property, string val)
    {
        List<DataItem> repository = new List<DataItem>(){
            new DataItem() {
                new Data("Name", "Mike"),
                new Data("Age", 25),
                new Data("BirthDate", new DateTime(1987, 1, 5))
            },
            new DataItem() {
                new Data("Name", "Steve"),
                new Data("Age", 30),
                new Data("BirthDate", new DateTime(1982, 1, 10))
            }
        };
        
        string whereClause = "{0}(it[\"{1}\"]) == {2}";
        
        
        // Discover the type at runtime (and convert accordingly)
        Type type = repository.First()[property].GetType();
        string stype = type.ToString();
        stype = stype.Substring(stype.LastIndexOf('.') + 1);
        
        if (type.Equals(typeof(string))) {
            // Need to surround formatting directive with ""
            whereClause = whereClause.Replace("{2}", "\"{2}\"");
        }
        string predicate = String.Format(whereClause, stype, property, val);
        
        var result = repository.AsQueryable<DataItem>().Where(predicate);
        if (result.Count() == 1)
            Console.WriteLine(result.Single()["Name"]);
    }
    
    var p = new Program();
    p.DynamicQueryExample("Age", "30");
    p.DynamicQueryExample("BirthDate", "DateTime(1982, 1, 10)");
    p.DynamicQueryExample("Name", "Mike");
