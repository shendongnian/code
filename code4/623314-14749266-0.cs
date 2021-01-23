    public class DateTimeWithFormat
    {
      public DateTime Date {get; set;}
      public string Format {get; set;}
      //ToString override using custom format
      public override string ToString 
       {
         return Date.ToString (Format);
         }    
     //Constructor sets date and format
      public DateTimeWithFormat( DateTime date, string format )
       {
         Date= date;
         Format = format;
        }
    }
