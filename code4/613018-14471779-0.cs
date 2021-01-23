    using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=school.mdb"))
    {
        conn.Open();
        string sql = "select * from sheet1 where student='stu2'";
        using (OleDbCommand command = new OleDbCommand(sql, conn))
        {
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0} ", reader[i]);
                    }
                    Console.WriteLine();
                }
            }
        }
        conn.Close();
    }
