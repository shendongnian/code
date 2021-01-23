    [WebMethod()]
    public double GetDayCount(string strMeetingDate, string strMeetingTime)
    {
        string[] strStartDateParts = strMeetingDate.Split('-');
        // not sure what your expected time format is
        string[] srtStartTimeParts = strMeetingTime.Split('-');
        
        int year = Int32.Parse(strStartDateParts[2]);
        int month = Int32.Parse(strStartDateParts[1]);
        int day = Int32.Parse(strStartDateParts[0]);
        int hour = Int32.Parse(srtStartTimeParts[0]);
        int min = Int32.Parse(srtStartTimeParts[1]);
        int sec = Int32.Parse(srtStartTimeParts[2]);
        
        DateTime meetingDate = new DateTime(year, month, day, hour, min, sec);
         using (connection = new SqlConnection(ConfigurationManager.AppSettings["connString"]))
        {
             using (command = new SqlCommand("BusinessHours", connection))
            {
                 command.CommandType = CommandType.StoredProcedure;
                 command.Parameters.Add("@meeting_date", SqlDbType.DateTime).Value = meetingDate;
                 connection.Open();
                 using (reader = command.ExecuteReader())
                {
                    reader.Read();
                    return (double)reader["hours"];
                }
            }
        }
    }
