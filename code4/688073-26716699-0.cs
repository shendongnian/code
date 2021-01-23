    public List<MyCustomObject> SelectLoad(DateTime parameter1, DateTime parameter2)
    {          
           return Execute("MyStoredProcedure @Parameter1, @Parameter2",
               new object[]{new SqlParameter("@Parameter1", parameter1),
               new SqlParameter("Parameter2",parameter2)});
    }
            
    private List<MyCustomObject> Execute(string query, object[] parameters)
    {
        var output = new List<MyCustomObject>();
        using (var dbContext = new MyEntityFrameworkDataContext())
        {
        output = dbContext.Database.SqlQuery<MyCustomObject>(query, parameters).ToList();
        }
        return output;        
    }
