    static void GenerateReport(object sender, EventArgs e)
        {
            if (TypeOfReport == "BillingReport")
            {
               ......
               DateOfExecution = DateTime.Parse(strDOE);
               Schedule.PeriodicSchedules s = new Schedule.PeriodicSchedules(DateOfExecution, Schedule.PeriodicSchedules.Frequency.Minutely);
               //weekly
               DateTime StartDate = DateOfExecution.AddDays(-7);
               DateTime EndDate = DateOfExecution.AddDays(-1);
               ..........
               UpdateWeekly(DateOfExecution, strReportType);             
            }        
        }
    static void UpdateWeekly(DateTime DateOfExecution, String strReportType)
        {
            DateOfExecution = DateOfExecution.AddMinutes(2);
            SqlConnection thisConnection = new SqlConnection(SQLConnection);
            thisConnection.Open();
            SqlCommand thisCommand = thisConnection.CreateCommand();
            //thisCommand.CommandText = "INSERT INTO dbo.Schedules (DateOfExecution)" + "Values('"+DateOfExecution+"')";
            thisCommand.CommandText = "UPDATE dbo.Schedule set DateOfExecution = '" + DateOfExecution + "' WHERE TypeOfReport = '" + strReportType + "'";
            thisCommand.ExecuteNonQuery();
        }
