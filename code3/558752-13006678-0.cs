    DateTime? SelDate = myCalendarExtender.SelectedDate;
    if (SelDate != null)
    {
        DateTime SelectedDate = SelDate .Value;
    }
    DateTime Selected_Date= SelectedDate ;
       
    DateTime result= Selected_Date.AddDays(30);
