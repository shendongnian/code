        // Local variable SqlCommand
        SqlCommand Command = new SqlCommand();
        // Text and Comment columns in square brackets, not sure for Comment,
        // but Text is a word used by T-SQL
        Command.CommandText = "INSERT INTO Response (ResponseID, SurveyID, TextID, " + 
                                  "AnswerID, [Text], [Comment]) VALUES (@ResponseID, @SurveyID, " + 
                                  "@TextID, @AnswerID, @Text, @Comment)";
        // Optimization, create parameters only one time
        Command.Parameters.AddWithValue("@ResponseID", -1);
        Command.Parameters.AddWithValue("@SurveyID", SurveyID);
        Command.Parameters.AddWithValue("@TextID", -1);
        Command.Parameters.AddWithValue("@AnswerID", -1]);
        Command.Parameters.AddWithValue("@Text", string.Empty);
        Command.Parameters.AddWithValue("@Comment", string.Empty);
        Command.CommandType = CommandType.Text;
        Command.Connection = conn;
        Command.Connection.Open();
        for (int i = 0; i < arrAnswerID.Count; i++)
        {
            Command.Parameters["@ResponseID"].Value = GetResponseId();
            Command.Parameters["@TextID"].Value = arrTextID[i];
            Command.Parameters["@AnswerID"].Value = arrAnswerID[i];
            Command.Parameters["@Text"].Value = arrText[i].ToString();
            Command.ExecuteNonQuery();
        }
        Command.Connection.Close();
