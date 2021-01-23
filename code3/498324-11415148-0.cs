    DataTable myTable = new DataTable();    
    string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\temp\test.xls;" + 
                  "Extended Properties='Excel 8.0;HDR=No;'";
    using(OleDbConnection c = new OleDbConnection(con))
    {
        c.Open();
        string selectString = "SELECT * FROM [Sheet1$]";
        using(OleDbCommand cmd1 = new OleDbCommand(selectString))
        {
            cmd1.Connection = c;
            using (OleDbDataReader myReader = cmd1.ExecuteReader())
            {
                myTable.Load(myReader);
            }
        }
    }
