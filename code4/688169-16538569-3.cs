    static class DBConnectivity
    {
        public static List<MasterTableAttributes> GetMasterTableList()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string masterSelectQuery = "SELECT * FROM MASTER_TABLE";
                using(var command = new SqlCommand(masterSelectQuery, connection))
                using(var dataReader = command.ExecuteReader())
                {
                    var masterTableList = new List<MasterTableAttributes>();
                    while (dataReader.Read())
                    {
                        MasterTableAttributes masterTableAttribute = new MasterTableAttributes()
                        {
                            fileId = Convert.ToInt32(dataReader["Id"]),
                            fileName = Convert.ToString(dataReader["FileName"]),
                            frequency = Convert.ToString(dataReader["Frequency"]),
                            scheduledTime = Convert.ToString(dataReader["Scheduled_Time"])
                        };
                        masterTableList.Add(masterTableAttribute);
                    }
                    return masterTableList;
                }
            }
        }
    }
