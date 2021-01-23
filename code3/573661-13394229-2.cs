    public static class Extensions
    {
      public static bool TryGetInt(this TextBox tb, out int value)
      {
        int i;
        bool parsed = int.TryParse(tb.Text, out i);
        value = i;
        return parsed;
      }
    }  
