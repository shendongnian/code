    static class DBConnectivity
    {
        public static List<MasterTableAttributes> GetMasterTableList()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = "SELECT Id as [FileId], FileName, Frequency, Scheduled_Time as [ScheduledTime] FROM MASTER_TABLE";
                return connection.Query<MasterTableAttributes>(sql).ToList();
            }
        }
    }
