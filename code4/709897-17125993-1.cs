    using(OleDbConnection conn = new OleDbConnection ())
    {
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + 
                                "Data Source=|DataDirectory|\\Manager.accdb;" + 
                               "Persist Security Info=False";
        DataTable schema = con.GetSchema("Tables");
        foreach(DataRow r in schema.Rows)
        {
            string table = r["TABLE_NAME"].ToString();
            Console.WriteLine(table);
            if(table == "Emplyee" || table == "Tasks" || table == "Projects")
                 combobox.Items.Add(table);
        }
    }
