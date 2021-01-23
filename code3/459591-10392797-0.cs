    public void TestMethod()
            {
                string connectionstring = "someconnectionstring";
                string deletesql = "delete from table where something = somethingelse";
                using(OleDbConnection con = new OleDbConnection(connectionstring))
                {
                    con.Open();
                    using(OleDbCommand com = new OleDbCommand(deletesql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
