    public void setAppointment(int studentID, DateTime appt)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = "UPDATE dbo.students SET appointmentDate = @appointmentDate WHERE ID = @ID";
            con.Open();
            cmd.Parameters.AddWithValue("@appointmentDate", appt);
            cmd.Parameters.AddWithValue("@ID", studentID);
            cmd.ExecuteNonQuery();
        }
    }
