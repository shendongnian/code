    internal bool AddRecord()
            {
                 string SQL = "exec SqlInsert ";
    
                 SQL += "'" + PrepeareForSql(_sqlComputer) + "', ";
                 SQL += "'" + PrepeareForSql(_lastUpdatedBy) + "', ";
                 SQL += "'" + DateTime.Now + "', ";
                 SQL += "'" + PrepeareForSql(_softwareName) + "' ";
    
                 return SqlDatabase.Overig(SQL);
            }
    
    private string PrepeareForSql(string s)
    {
       return s.Replace("'","''");
    }
