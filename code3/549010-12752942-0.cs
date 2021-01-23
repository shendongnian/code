    int intCounter = 0;
    string strWeekName = "";
    string strContent = "Some text wednesday";
    strContent = strContent.ToUpper;
    while (intCounter < 7) {
	  if (strContent.Contains(DateAndTime.WeekdayName(intCounter).ToUpper())) {
		  strWeekName = DateAndTime.WeekdayName(intCounter);
		  break; 
	  }
      intCounter++; 
    }
    MsgBox "Weekday " + strWeekName;
