    // Variant 1: Using strings all the way
    public void DynamicQueryExample(string property, dynamic val)
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
        
        // Use string comparison all the time        
        string predicate = "it[\"{0}\"].ToString() == \"{1}\"";
        predicate = String.Format(whereClause , property, val.ToString());
        
        var result = repository.AsQueryable<DataItem>().Where(predicate);
        if (result.Count() == 1)
            Console.WriteLine(result.Single()["Name"]);
    }
    Program p = new Program();
    p.DynamicQueryExample("Age", 30); // Prints "Steve"
    p.DynamicQueryExample("BirthDate", new DateTime(1982, 1, 10)); // Prints "Steve"
    p.DynamicQueryExample("Name", "Mike"); // Prints "Steve" (nah, just joking...)
