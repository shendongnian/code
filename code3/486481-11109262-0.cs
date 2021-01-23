    // To get the Time of right now 
    DateTime oNow = DateTime.Today;
    
    // Get your entered Time assuming it is Entered YYYY/MM/DD
    string sEnteredDate = DateTextBox.Text;
    
    // Edit the String to get Year, Month, Day
    string sEnteredYear = sEnteredDate.Substring(0, 4);
    string sEnteredMonth = sEnteredDate.Substring(5, 2);
    string sEnteredDay = sEnteredDate.Substring(8, 2);
    
    // Create final DateTime
    DateTime oDateForDb = oNow;
    
    oDateForDb.Day = sEnteredDay;
    oDateForDb.Month = sEnteredMonth;
    oDateForDb.Year = sEnteredYear;
