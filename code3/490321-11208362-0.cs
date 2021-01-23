    string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=your_path\test.xls;Extended Properties='Excel 8.0;HDR=No;'";
    using(OleDbConnection c = new OleDbConnection(con))
    {
        c.Open();
        string commandString = "Insert into [Sheet1$] (F1, F2, F3) values('F1Text', 'F2Text', 'F3Text')" ;
        using(OleDbCommand cmd = new OleDbCommand(commandString))
        {
    		cmd.Connection = c;
    		cmd.ExecuteNonQuery();
        }
    }
