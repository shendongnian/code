    public class Connection
        {
            /// <summary>
            /// Connection String
            /// </summary>
            public static string ConnectionString
            {
                get
                {
                    return ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
                }
            }
        }
    //Returning connction string
     sqlConnection conn = new SqlConnection(Connection.ConnectionString);  
