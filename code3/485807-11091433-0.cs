    [Microsoft.SqlServer.Server.SqlProcedure]
        public static void MyMethod()
        {
            string connectionString = "context connection=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlMetaData[] metaData = {
                                             new SqlMetaData("Column1", System.Data.SqlDbType.VarChar)
                                             ,new SqlMetaData("Column2", System.Data.SqlDbType.VarChar)
                                         };
                SqlDataRecord record = new SqlDataRecord(metaData);
                record.SetString(0,"hello world");
                SqlContext.Pipe.SendResultsRow(record);
            }
        }
