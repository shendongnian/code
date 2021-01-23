        private void GetXmlFromSql()
        {
            XmlDocument xdoc = new XmlDocument();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = "mm connect string";
                    connection.Open();
                    string queryString = "my query";
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        XmlReader reader = command.ExecuteXmlReader();
                        if (reader.Read())
                        {
                            xdoc.Load(reader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
              
            }
        }
