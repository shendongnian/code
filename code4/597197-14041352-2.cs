         string sSQL = "SELECT treatment FROM appointment WHERE patientid = @patientId";
         OleDbCommand cmd1 = new OleDbCommand(sSQL, GetConnection()); // This may be slight different based on what `GetConnectionReturns`, just put the connection string in the second parameter.
            
            
            cmd1.Parameters.AddWithValue("@patientId", text);
            SqlDataReader reader = cmd1.ExecuteReader();
            string returnValue;
            while(reader.Read())
            {
               returnValue = reader[0].ToString();
            }
