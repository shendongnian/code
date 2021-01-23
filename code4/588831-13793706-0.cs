    public static List<string> GetDistinctValues( string Field ) 
    {
        var query = db.MyTable.Select(Field).Distinct();
        ...
    }
    
