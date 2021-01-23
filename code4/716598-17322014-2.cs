    public class CustomDateAttribute : RangeAttribute
    {
      public CustomDateAttribute()
        : base(typeof(DateTime), 
                DateTime.Now.AddYears(-6).ToShortDateString(),
                DateTime.Now.ToShortDateString()) 
      { } 
    }
