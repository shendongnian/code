        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void MyMethod()
        {
            string connectionString = "context connection=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlMetaData[] metaData = {
                                             new SqlMetaData("Column1", System.Data.SqlDbType.NVarChar, 100)//Max length has to be specified
                                             ,new SqlMetaData("Column1", System.Data.SqlDbType.NVarChar, 100)//same story
                                         };
                SqlDataRecord record = new SqlDataRecord(metaData);
                SqlContext.Pipe.SendResultsStart(record);//SendResultsStart must be called
                
                //create a row and send it down the pipe
                record.SetString(0,"hello world");
                SqlContext.Pipe.SendResultsRow(record);
                SqlContext.Pipe.SendResultsEnd();//End it out
            }
        }
