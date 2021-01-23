    DateTime date = new Date(2005, 10, 03);
    List<DateTime> dates = new List<DateTime>();
    do
    {
       var newDate = date.Add(7);  
       dates.Add(newDate);
    }While(newDate.Month == 10)
