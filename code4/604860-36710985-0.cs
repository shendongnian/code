            OleDbConnection POCcon = new OleDbConnection(POCConnection);
            OleDbCommand POCcommand = new OleDbCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter POCCommand = new OleDbDataAdapter("select * from [Sheet1$] ", POCcon);
            POCCommand.Fill(dt);
            Console.WriteLine(dt.Rows.Count);
