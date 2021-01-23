    private Student GetStudent(int studentID)
    {
        string connString = @"Data Source=PC-PC\PC;Initial Catalog=Test;Integrated Security=True";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "SELECT * FROM Entry WHERE StudentID = @studentID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@studentID", SqlDbType.Int).Value = studentID;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
                 throw new Exception("Student not found");
            return new Student()
            {
                Id = (int)reader["StudentID"],
                Name = (string)reader["StudentName"],
                Grade = (string)reader["Grade"]
            };
        }
    }
