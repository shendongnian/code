     var existingDay =
     db.WeatherTBL.SingleOrDefault(d => d.DateTime.Equals(day.Date.ToString()));
           
     if(existingDay != null)
      {
       //so on...
      }
           
 
