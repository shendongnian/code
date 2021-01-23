    public static void Thing<T>(this T model) where T : class 
    {
      var t = typeof(T);
      var props =
        t.GetProperties()
         .Select(p => new { p, attr = p.GetCustomAttributes(typeof(DisplayAttribute), false) })
         .Where(t1 => t1.attr.Length != 0)
         .Select(t1 => t1.p).ToList();
      foreach (var prop in props)
      {
        // Do something
      }
    }
