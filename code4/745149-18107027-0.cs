    public class Time
    {
       //
       //  { get; set; } Using this, the compiler will create automatically
       //  the body to get and set.
       //
       public int Hour { get; set; } // Propertie that defines hour
       public int Minute { get; set; } // Propertie that defines minute 
       public int Second { get; set; } // Propertie that defines seconds 
       //
       // Default Constructor from the class Time, Initialize
       // each propertie with a default value
       // Default constructors doesn't have any parameter
       //
       public Time()
       {
          Hour = 0;
          Minute = 0;
          Second = 0;
       }
       
       //
       // Parametrized Constructor from the class Time, Initialize
       // each propertie with given values
       //
       public Time(int hour, int Minute, int second)
       {
          Hour = hour;
          Minute = minute;
          Second = second;
       }
    }
