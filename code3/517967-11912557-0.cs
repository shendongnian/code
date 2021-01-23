        public IEnumerable<string> PopulateTeamMembers()
        {
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
                        yield return reader[0].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    return "Error, unable to load";
                }
            }
        }
