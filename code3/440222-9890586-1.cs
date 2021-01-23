    public static SqlDataReader ReadFromDB(string inputSQLStatement)
    {
        //Does some actual work here ..
    }
    
    public static DataTable ReadDataTableFromDB(string inputSQLStatement)
    {
        return new DataTable().Load(ReadFromDB(inputSQLStatement));
    }
