    var dateStart = new DateTime();
    var dateEnd = new DateTime();
    
    if(dateTime !=null)
    {  
         dateStart = Convert.ToDateTime(dateTime);
         dateEnd = new DateTime(dateStart.Year, dateStart.Month, 5).AddMonths(1);
    }
    else
    {
         if (DateTime.Today.Day <= 4)
         {
              dateStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 5).AddMonths(-1);
              dateEnd = dateStart.AddMonths(1);
         }
         else
         { 
              dateStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 5);
              dateEnd = dateStart .AddMonths(1);
         }
    }
