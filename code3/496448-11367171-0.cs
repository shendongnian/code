    public class MyConnectionManager : IDisposable
            {
                [ThreadStatic] // static per thread
                private static OleDbConnection con;
    
                public static OleDbConnection Connection
                {
                    get
                    {
                        if (con == null)
                        {
                            con = new OleDbConnection(ConfigurationManager.ConnectionStrings["OracleDataBase"].ConnectionString);
                            con.Open();
                        }
                        return con;
                    }
                }
    
                public void Dispose()
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
    
    private static DataTable setResultSet(string sChoice, string sFeat, string sSearch)
            {
                DataTable dtTemp = new DataTable();
                string sQuery = setSqlQuery(sChoice, sFeat, sSearch);
    
                // Instantiate the Command Object
                OleDbCommand dbCommand = new OleDbCommand(sQuery, MyConnectionManager.Connection);
                dbCommand.CommandType = CommandType.Text;
    
                // Execute the Stored Procedure
                OleDbDataReader dr = dbCommand.ExecuteReader();
    
                dtTemp = setResultSetRows(dtTemp, sChoice, dr);
    
                return dtTemp;
    
    	}
    
            public static DataTable getResultSet(string sChoice, string sFeat, string sSearch)
            {
                return setResultSet(sChoice, sFeat, sSearch);
            }
