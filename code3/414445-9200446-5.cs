    public List<T> ImportTable<T>(String fileName, String table)
    {
        //Establish Connection to Access Database File
        var mdbData = new ConnectToAccess(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\ACCESS\" + fileName + ".mdb;");
    
        var tableData = new List<T>();
    
        foreach (DataRow row in mdbData.GetData("SELECT * FROM " + table).Rows)
        {
            tableData.Add(row.ToType<T>());
        }
    
        return tableData;
    }
