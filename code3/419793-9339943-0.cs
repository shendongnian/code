    public class Time
    {
         private int month;
         private int day;
         private int year;
         
         public override string ToString()
         {
               if(month == 0 || day == 0 || year == 0)
               {
                     return "~~unspecified~~";
               }
               DateTime date = new DateTime(year, month, day);
               return date.ToString();
         }
    }
