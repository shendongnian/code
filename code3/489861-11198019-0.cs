    System.Data.DataTable ExecuteSql(DateTime BusinessDate)
    {
    
        System.Data.DataTable ReturnValue = new System.Data.DataTable;
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDb.Command(connectionString, "Select * From myTable WHERE TimestampColumn BETWEEN @StartDate AND @EndDate");
        // For start date, we can't assume the user has passed in a date with a 
        // midnight time, so first, use DateTime.Date to get JUST the date at midnight, 
        // then add 7 hours to get to the desired start time.
        // For example, if the calling code had passed in 1/1/2001 8:00 AM we would use
        // the .Date property to get it to 1/1/2001 12:00 AM
        // and then add 7 hours.
        cmd.Parameters.Add(@StartDate, BusinessDate.Date.AddHours(7));
        cmd.Parameters.Add(@EndDate, BusinessDate.Date.AddHours(31));  // 24 + 7
        System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(cmd);
        ad.Fill(ReturnValue)    
    
    }
