    private void GetData()
            {
                cmd.Parameters.Clear();
                SqlParameter SName = new SqlParameter("@SName", SqlDbType.VarChar);
                SName.Direction = ParameterDirection.Output;
                SName.Size = 35;
                cmd.Parameters.Add(SName);
                dm.ExectNonActQuery("TestRecordSelectMInfo", cmd);
                tbsname.Text = cmd.Parameters["@SName"].Value.ToString();
            }
            public void ExectNonActQuery(string spname, SqlCommand command)
            {
                SqlConnection cn = new SqlConnection("connection string");
                cmd = command;
                cmd.Connection = cn;
                cmd.CommandText = spname;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
