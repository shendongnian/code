    public void setAppointment(int studentID, DateTime appt)
            {
                 
    connection.Open();
        string sqlStatement3 = "UPDATE dbo.students SET appointmentDate = '" + "CONVERT(datetime, '" + appt.Date.ToString("yyyy-MM-dd HH:mm:ss")  + "', 103)" + "' WHERE ID = " + studentID + ";";
        OleDbCommand updateCommand = new OleDbCommand(sqlStatement3, connection);            
        updateCommand.ExecuteNonQuery();
        connection.Close();
    }
