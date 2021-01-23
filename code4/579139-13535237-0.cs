    SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLExpress;" + "Trusted_Connection=True;" + "User Instance=True;" + "AttachDbFilename=|DataDirectory|\\fbi.mdf;";
            string sqlQuery4 = "SELECT Car FROM tbl1 JOIN tbl2 ON (tbl1.userID = tbl2.userID) WHERE tbl2.username='Bob'";
            SqlCommand cmd4 = new SqlCommand(sqlQuery4, conn);
            conn.Open();
            SqlDataReader rd = cmd4.ExecuteReader();
    
    
                    ddl1.DataSource = rd;
                    ddl1..DataTextField = "columnname"; //your column name
                    ddl1.DataValueField = "columnname";
                    ddl1.DataBind();
                                      
                    rd.Close();
                    conn.Close();
