    static void Main(string[] args)
    {
        var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\__tmp\accounting.accdb;");
        conn.Open();
        var cmd = new OleDbCommand("SELECT * FROM ExpenseDetails", conn);
        OleDbDataReader rdr = cmd.ExecuteReader();
        int rowCount = 0;
        while (rdr.Read())
        {
            rowCount++;
            Console.WriteLine("Row " + rowCount.ToString() + ":");
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                string colName = rdr.GetName(i);
                Console.WriteLine("  " + colName + ": " + rdr[colName].ToString());
            }
        }
        rdr.Close();
        conn.Close();
    
        Console.WriteLine("Done.");
        Console.ReadKey();
    }
