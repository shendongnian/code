      public static class DateTimeHelper
      {
        public static DateTime Tomorrow
        {
          get { return DateTime.Today.AddDays(1); }
        }
      }
.
      <CalendarDateRange Start="{x:Static app:DateTimeHelper.Tomorrow}"…
