    private System.Data.DataTable ExecuteSql(DateTime BusinessDate)
    {
    
        System.Data.DataTable ReturnValue = new System.Data.DataTable;
        string sql = "Select * From myTable WHERE TimestampColumn >= @StartDate AND TimestampColumn < @EndDate";
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDb.Command(connectionString, sql);
        // For start date, we can't assume the user has passed in a date with a 
        // midnight time, so first, use DateTime.Date to get JUST the date at midnight, 
        // then add 7 hours to get to the desired start time.
        // For example, if the calling code had passed in 1/1/2001 8:00 AM we would use
        // the .Date property to get it to 1/1/2001 12:00 AM
        // and then add 7 hours.
        cmd.Parameters.Add(@StartDate, BusinessDate.Date.AddHours(7));
        // The end date - same logic, but instead of adding 7 hours, add 31 
        // (24 hours + 7 hours = 31 hours)
        cmd.Parameters.Add(@EndDate, BusinessDate.Date.AddHours(31));  // 24 + 7
        System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(cmd);
        ad.Fill(ReturnValue)    
    
        return ReturnValue;
    }
