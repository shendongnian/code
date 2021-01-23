    using (var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\__tmp\testData.accdb;"))
    {
        conn.Open();
        using (var cmd = new OleDbCommand(
                "UPDATE Ontwikkeldossier SET [In mail]=? WHERE OntwikkeldossierID=?",
                conn))
        {
            cmd.Parameters.AddWithValue("?", false);
            cmd.Parameters.AddWithValue("?", 1);
            cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
            
