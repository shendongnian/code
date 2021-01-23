            string connetionString = null;
            OleDbConnection connection ;
            OleDbDataAdapter oledbAdapter ;
            OleDbCommandBuilder oledbCmdBuilder ;
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Your mdb filename;";
            connection = new OleDbConnection(connetionString);
            sql = "select * from tblUsers";
            try
            {
                connection.Open();  // your code must have like this
                oledbAdapter = new OleDbDataAdapter(sql, connection);
                oledbCmdBuilder = new OleDbCommandBuilder(oledbAdapter);
                oledbAdapter.Fill(ds);
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    ds.Tables[0].Rows[i].ItemArray[2] = "neweamil@email.com";
                }
                oledbAdapter.Update(ds.Tables[0]);
                connection.Close();
                MessageBox.Show ("Email address updates !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
