           string SqlString = "Insert Into Accountstbl (Username, Password) Values (@user, @pass)";
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\test.accdb")) //Your Connection string
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@use", "test");
                    cmd.Parameters.AddWithValue("@pass", "test1");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
