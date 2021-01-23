    thatButton.Click += (the, game) => 
    {
       db = new OleDbConnection();
       db.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + fileName;
       db.Open();
       string sql = "SELECT * FROM Table WHERE SomeField = '" + ChoiceTxtBox.Text + "'";
       cmd = new OleDbCommand(sql, db);
       rdr = cmd.ExecuteReader();
       while (rdr.Read())
       resultTxtBox.Text += ((string)rdr["GroupName"]);
    };
