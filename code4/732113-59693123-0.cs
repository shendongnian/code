        public DataTable method(string query)
           {
               string connection = @"Data Source= C:\User\DBFolder\sampleDB.db;Version=3;New=False;Compress=True;";
            
               using (IDbConnection dbConnection = new SQLiteConnection(connection))
                {
                    dbConnection.Open();
                    var output1 = dbConnection.Query(query).ToList();
                    dbConnection.Close();
                    var json = JsonConvert.SerializeObject(output1);
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                    return dt;
                }
            }
