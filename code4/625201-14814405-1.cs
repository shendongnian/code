    /// <summary>
    /// SYSTEMTIME structure with some useful methods
    /// </summary>
    public struct SYSTEMTIME {
      public short Year, Month, DayOfWeek, Day, Hour, Minute, Second, Millisecond;
      /// <summary>
      /// Convert form System.DateTime
      /// </summary>
      /// <param name="time">Creates System Time from this variable</param>
      public void FromDateTime(DateTime time) {
        Year = (short)time.Year;
        Month = (short)time.Month;
        DayOfWeek = (short)time.DayOfWeek;
        Day = (short)time.Day;
        Hour = (short)time.Hour;
        Minute = (short)time.Minute;
        Second = (short)time.Second;
        Millisecond = (short)time.Millisecond;
      }
      /// <summary>
      /// Convert to System.DateTime
      /// </summary>
      public DateTime ToDateTime() {
        return new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
      }
      /// <summary>
      /// STATIC: Convert to System.DateTime
      /// </summary>
      public static DateTime ToDateTime(SYSTEMTIME time) {
        return time.ToDateTime();
      }
    }
