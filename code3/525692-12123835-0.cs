    public class CustomDate
    {
       public int? Day { get; set; }
    
       public int? Month { get; set; }
    
       public int Year { get; set; }
    
       public DateTime? Date
       {
          get
          {
            if(Year > 0 && Day.HasValue && Day.Value > 0 
               && Month.HasValue && Month.Value > 0)
                return new DateTime(Year, Month.Value, Day.Value);
             return null;
          }
       }
    }
