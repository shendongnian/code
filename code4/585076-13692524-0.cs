    String sBeginDate = "";//Given in input
    String sEndDate = "";//Given in input
    DateTime weekStartDate;
    DateTime weekEndDate;
    DataTable dtWeeksInRange = new DataTable();                
    DataColumn dcWeekStart = new DataColumn("WeekStart");
    DataColumn dcWeekEnd = new DataColumn("WeekEnd");        
    dtWeeksInRange.Columns.Add(dcWeekStart);
    dtWeeksInRange.Columns.Add(dcWeekEnd);
    DayOfWeek firstday = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;        
         weekStartDate = Convert.ToDateTime(sBeginDate) ;
        do
        {            
          while (weekStartDate.DayOfWeek != firstday) 
               { 
                  weekStartDate = weekStartDate.AddDays(-1); 
               }
            weekEndDate = weekStartDate.AddDays(6);
            dtWeeksInRange.Rows.Add(weekStartDate, weekEndDate);
            weekStartDate = weekEndDate.AddDays(1);            
        }
          while ((Convert.ToDateTime(sEndDate).Subtract(weekEndDate)).Days > 0);
    foreach (DataRow dr in dtWeeksInRange.Rows)
        {
          //Outputting the set of dates to the page
            Response.Write(Convert.ToDateTime(dr["WeekStart"]).ToShortDateString() + 
            " - " + 
            Convert.ToDateTime(dr["WeekEnd"]).ToShortDateString() + 
            "<br />");
        }
