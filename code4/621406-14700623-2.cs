           string SqlString = "Insert Into Accountstbl (Username, Password) Values (@user, @pass)";
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\test.accdb")) //Your Connection string
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    string use = userTextBox.Text;
                    string pass = passTextBox.Text;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@use", use);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
