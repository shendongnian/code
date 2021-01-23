            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=the directory or the path of your database";
            string query = "SELECT * From Table Name";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                conn.Close();
            }
