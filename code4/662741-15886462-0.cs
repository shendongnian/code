    static void Main(string[] args)
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\Administrator\Desktop\Database1.accdb;");
        conn.Open();
    
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM myTable", conn);
        OleDbDataReader rdr = cmd.ExecuteReader();
    
        int rowNumber = 0;
        while (rdr.Read())
        {
            rowNumber++;
            Console.WriteLine("Row " + rowNumber.ToString() + ":");
            for (int colIdx = 0; colIdx < rdr.FieldCount; colIdx++)
            {
                string colName = rdr.GetName(colIdx);
                Console.WriteLine("    rdr[\"" + colName + "\"]: " + rdr[colName].ToString());
            }
        }
        rdr.Close();
        conn.Close();
    
        Console.WriteLine("Done.");
        Console.ReadKey();
    }
