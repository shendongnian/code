     OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=Excel 12.0;");
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                OleDbDataReader dr;
                connection.Open();
                dr = command.ExecuteReader(CommandBehavior.CloseConnection);
    
                //dbo.Employees
    
                cn.Open();
                dt.Load(dr);
                cn.Close();
