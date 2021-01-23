    public class DateAttribute : RangeAttribute
    {
      public DateAttribute()
        : base(typeof(DateTime), 
                DateTime.Now.AddYears(-6).ToShortDateString(),
                DateTime.Now.ToShortDateString()) 
            { } 
    }
