    public List<T> GetRecipesThatContain<T>(string ingredient)
    {
        const string commandText = "SELECT Recipe_Name FROM New_Recipe WHERE ingredient1 LIKE @SearchTerm";
        var searchTerm = Contains(ingredient);
        using(var connection = GetSqlConnection())
        {
            connection.Open();
            using(var command = new SqlCommand(commandText, connection);
            {
                command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                using(var reader = command.ExecuteReader())
                {
                    var results = new List<T>();
                    while(reader.Read())
                    {
                        // Get results
                        // results.Add(result);
                    }
                    return results;
                }
            }
        }
    }
   
    private string StartsWith(string searchTerm)
    {
        return string.Format("{0}%", searchTerm);
    }
    private string EndsWith(string searchTerm)
    {
        return string.Format("%{0}", searchTerm);
    }
    private string Contains(string searchTerm)
    {
        return string.Format("%{0}%", searchTerm);
    }
