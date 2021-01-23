    private static DateTime nodate = new DateTime(1900, 1, 1);
    public static DateTime NODATE { get { return nodate; } }
    public static DateTime GetDate(object obj) {
      if ((obj != null) && (obj != DBNull.Value)) { // Databases return DBNull.Value
        try {
          return Convert.ToDateTime(obj);
        } catch (Exception) { }
        try {
          return DateTime.Parse(obj.ToString());
        } catch (Exception) { }
      }
      return NODATE;
    }
