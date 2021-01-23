        public IEnumerable<string> PopulateTeamMembers()
        {
            List<string> returnList = new List<string>();
            string queryString = "select    setting_main"
                                 + " from     [marlin].[support_config]"
                                 + " where  config_code = 30"
                                 + "         and setting_active = 1"
                                 + " order by setting_main";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        returnList.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Just let the calling class handle the exception
                    throw;
                }
            }
            return returnList;
        }
