        private static readonly object Locker = new object();
        public void AddQuestion(string title, string question, string answer)
        {
            lock (Locker)
            {
                try
                {
                    sqlConnection = new SqlConnection("");
                    sqlCommand = new SqlCommand("INSERT INTO QuestionTable VALUES(@Title, @Question, @Answer)", sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Question", question));
                    sqlCommand.Parameters.Add(new SqlParameter("@Answer", answer));
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("That is the Error:" ex.ToString()); // post this Text if it doesn't work
                    throw (ex);
                }
            }
        }
