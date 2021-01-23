        [WebMethod]
        public string[] GetNames(string prefixText, int count)
        {
            List<string> items = new List<string>();
            string cs = ConfigurationManager.ConnectionStrings["CSLinker"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("SET ROWCOUNT @Count SELECT Name FROM TabProjects WHERE Name LIKE @Name + '%'", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = prefixText;
                    command.Parameters.Add(new SqlParameter("@Count", SqlDbType.Int, 8)).Value = count;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
            }
            return items.ToArray();
        }
