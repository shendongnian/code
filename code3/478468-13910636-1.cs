    public static MyDbObject GetDbObjectFromTable(int id)
    {
        string sql = @"SELECT Id FROM MyTable WHERE Id=@Id";
        dynamic param = new {Id = id}; // this Type dynamic is what causes the issue.
    
        // you could just fix with a cast to object
        return Query<MyDbObject>(sql, (object)param, mapper); 
    }
