    List<string> values = new List<string>();
    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\your\\path\\file.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=NO;\"";
    using (OleDbConnection conn = new OleDbConnection(constr))
    {
        conn.Open();
        OleDbCommand command = new OleDbCommand("Select * from [SheetName$]", conn);
        OleDbDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                // this assumes just one column, and the value is text
                string value = reader[0].ToString();
                values.Add(value);
            }
        }
    }
    foreach (string value in values)
        Console.WriteLine(value);
