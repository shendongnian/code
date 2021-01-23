    // Here is the simple wrapper method to get the first day of the month:
    public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
    {
       return new DateTime(dateTime.Year, dateTime.Month, 1);
    }
    
    // Set the due date...
    DueDate.Text = (FirstDayOfMonthFromDateTime(DateTime.Parse(StartDate.Text).AddMonths(N))).ToShortDateString();
