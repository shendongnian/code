     public DataTable CreateOrDropUser(string dataBase, string procedure, SqlParameter[] parameters)
        {
            SqlconnecitonStringBuilder scsb = new SqlConnectionStringBuilder (connstring);
            scsb.Database = database;
            using (SqlConnection con = new SqlConnection (scsb.ConnectionString))
            {
                StringBuilder sb = new StringBuilder ();
                con.Open ();
                SqlCommand cmd1 = new SqlCommand(procedure, con);
                cmd1.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parameters)
                {
                    if (p != null)
                    {
                        cmd1.Parameters.Add(p);
                    }
                }
                conn.InfoMessage += (args => 
                {
                  sb.AppendLine (args.Message);
                });
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                MessageBox.Show(sb);
                return dt;      
            }
        }
