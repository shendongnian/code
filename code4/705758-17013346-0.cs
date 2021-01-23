     public void setAppointment(int studentID, DateTime appt)
            {
                connection.Open();
    
                string sqlStatement3 = "UPDATE dbo.students SET appointmentDate = ? WHERE ID = ?";
    
                OleDbCommand updateCommand = new OleDbCommand(sqlStatement3, connection);
                updateCommand.Parameters.AddWithValue("@p1", appt);
                updateCommand.Parameters.AddWithValue("@p2", studentID);
                updateCommand.ExecuteNonQuery();
    
                connection.Close();
            }
