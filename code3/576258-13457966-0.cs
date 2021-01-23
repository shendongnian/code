    string ComStr = "UPDATE Contacts SET Category = @Category where [E-mail Address] in @List";
                using (OleDbConnection con = new OleDbConnection(ConnStr))
                {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand(ComStr, con))
                    {
                        
                        com.Parameters.AddWithValue("@Category", "Не получава мейли");
                        com.Parameters.AddWithValue("@List", list);
                        com.ExecuteNonQuery();
                    }
                    con.Close();
                } 
