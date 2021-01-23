    private string GetStudentName(int studentID)
    {
        string connString = @"Data Source=PC-PC\PC;Initial Catalog=Test;Integrated Security=True";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "SELECT StudenName FROM Entry WHERE StudentID = @studentID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@studentID", SqlDbType.Int).Value = studentID;
            conn.Open();
            return (string)cmd.ExecuteScalar();
        }
    }
