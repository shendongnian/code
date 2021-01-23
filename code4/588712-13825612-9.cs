    public class SQLDBInteraction
    {
        public class SqlParamList
        {
            public SqlCommand SqlCmd = new SqlCommand();
            public List<SqlParameter> SP_Params = new List<SqlParameter>();
            
            public string TableName;
            public string SelectCommand;
            ///public SqlCommandType SelectedCmdType;
        }
        public class DataContainer
        {
            public DataTable LocalTbl_V3(SqlParamList Params)
            {
                SqlConnection sqlConnection;
                DataTable retDt = new DataTable(Params.TableName);
                SqlDataAdapter sqlDataAdapter;
                using (sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["useyourwebconfigconnection"].ConnectionString))
                {
                    sqlConnection.Open();
                    using (Params.SqlCmd.Connection = sqlConnection)
                    {
                        using (sqlDataAdapter = new SqlDataAdapter(Params.SqlCmd.CommandText, sqlConnection))
                        {
                            if (sqlDataAdapter.SelectCommand.Parameters.Count > 0 == false)
                            {
                                sqlDataAdapter.SelectCommand = Params.SqlCmd;
                                sqlDataAdapter.Fill(Usrs);
                            }
                        }
                    }
                }
                return retDt;
            }
       }
    }
