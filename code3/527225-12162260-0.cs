    string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\test.xls;" + 
                  "Extended Properties='Excel 8.0;HDR=Yes;'";
    using(OleDbConnection c = new OleDbConnection(con))
    {
        c.Open();
        string selectString = "SELECT SUM(Amount) FROM [Sheet1$]";
        using(OleDbCommand cmd1 = new OleDbCommand(selectString))
        {
           cmd1.Connection = c;
	 var result = cmd1.ExecuteScalar();
           Console.WriteLine(result);
        }
     }
