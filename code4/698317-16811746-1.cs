    public void AddQuestion(string title, string question, string answer)
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO QuestionTable VALUES(@Title, @Question, @Answer)", sqlConnection))
        {
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@Title", title));
                sqlCommand.Parameters.Add(new SqlParameter("@Question", question));
                sqlCommand.Parameters.Add(new SqlParameter("@Answer", answer));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
