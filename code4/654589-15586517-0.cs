          OleDbConnection dbConnection = new OleDbConnection(CONNECTION_STRING);
            
            string commandString = 
            "INSERT INTO MeetingEntries (Subject, Location, Start Date, End Date, Enable   Alarm, Repeat Alarm, Reminder, Repetition Type)" + " VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            
            OleDbCommand commandStatement = new OleDbCommand(commandString, dbConnection);
            
            commandStatement.Parameters.Add("@Subject", OleDbType.VarWChar, 30).Value = currentEntry.Subject;
            commandStatement.Parameters.Add("@Location", OleDbType.VarWChar, 50).Value = currentEntry.Location;
            commandStatement.Parameters.Add("@Start Date", OleDbType.Date, 40).Value = currentEntry.StartDateTime.Date;
            commandStatement.Parameters.Add("@End Date", OleDbType.Date, 40).Value = currentEntry.EndDateTime.Date;
            commandStatement.Parameters.Add("@Enable Alarm", OleDbType.Boolean, 1).Value = currentEntry.IsAlarmEnabled;
            commandStatement.Parameters.Add("@Repeat Alarm", OleDbType.Boolean, 1).Value = currentEntry.IsAlarmRepeated;
            commandStatement.Parameters.Add("@Reminder", OleDbType.Integer, 2).Value = currentEntry.Reminder;
            commandStatement.Parameters.Add("@Repetition Type", OleDbType.VarWChar, 10).Value = currentEntry.Repetition;
            
            dbConnection.Open();
            commandStatement.ExecuteNonQuery();
