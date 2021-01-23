    public static string OnCoerceValue(DependencyObject dObject, object val)
        {
          if (val.ToString().CompareTo("Test") == 1)
          {
            return val.ToString();
          }
          **return string.Empty;**
        }
