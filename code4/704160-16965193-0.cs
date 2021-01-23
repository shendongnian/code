    public void Update_Download(string _url)
    {
        try
        {
            using (SqlConnection connexion = Data.Connect())
            {
                string queryString = "update Fichier set Last_download=@last , Downloads_count= Downloads_count + 1  where Url = @url ";
    
                using (SqlCommand command = new SqlCommand(queryString, connexion))
                {
                    command.Parameters.AddWithValue("@last", DateTime.Now);
                    command.Parameters.AddWithValue("@url", _url);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
