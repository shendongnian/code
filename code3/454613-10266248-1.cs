    private void GetData()
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@GRNo", SqlDbType.VarChar).Value = tbgrno.Text;
                SqlParameter SName = new SqlParameter("@SName", SqlDbType.VarChar);
                SqlParameter Class = new SqlParameter("@Class", SqlDbType.VarChar);
                SName.Direction = ParameterDirection.Output;
                Class.Direction = ParameterDirection.Output;
                SName.Size = 35;
                Class.Size = 15;
                cmd.Parameters.Add(SName);
                cmd.Parameters.Add(Class);
                dm.ExectNonActQuery("TestRecordSelectMInfo", cmd);
                tbsname.Text = cmd.Parameters["@SName"].Value.ToString();
                tbclass.Text = cmd.Parameters["@Class"].Value.ToString();
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
