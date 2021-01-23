            StringBuilder sb = new StringBuilder ();
            string sql = "SELECT CASE_ID, CLAIM_NR, CLAIM_PHS_CD FROM TABLENAME WHERE CASE_ID = :ci";
            //string sql = "SELECT CASE_ID, CLAIM_NR, CLAIM_PHS_CD FROM TABLENAME";
            using ( OracleConnection connection = new OracleConnection ( RegistryConnectionInformation.GetDBConnString () ) )
            {
                OracleParameter ci = new OracleParameter();
                ci.ParameterName = "ci";
                ci.Value = "12345";
                OracleCommand command = new OracleCommand ( sql, connection );
                command.Parameters.Add ( ci );
                connection.Open ();
                OracleDataReader reader = command.ExecuteReader ();
                try
                {
                    while ( reader.Read () )
                    {
                        sb.Append ( string.Format ( "{0} - {1} - {2}\n", reader [ 0 ], reader [ 1 ], reader [ 2 ] ) );
                    }
                }
                catch ( Exception ex )
                {
                    sb.Append ( string.Format ( "{0}\n\n{1}", ex.Message, ex.StackTrace ) );
                }
                finally
                {
                    reader.Close ();
                }
            }
            return sb.ToString ();
