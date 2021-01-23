    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    {
        using (var cmd = new SqlCommand("SELECT TOP 10 * FROM tabData; SELECT TOP 10 * FROM tabDataDetail;", con))
        {
            int rowCount = 0;
            con.Open();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    String object1 = String.Format("Object 1 in Row {0}: '{1}'", ++rowCount, rdr[0]);
                }
                if (rdr.NextResult())
                {
                    rowCount = 0;
                    while (rdr.Read())
                    {
                        String object1 = String.Format("Object 1 in Row {0}: '{1}'", ++rowCount, rdr[0]);
                    }
                }
            }
        }
    }
