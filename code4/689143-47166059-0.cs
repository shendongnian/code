      public static bool CheckNullOrEmpty<T>(T value)
      {
            // note: this does not see DBNull as isnullorempty.  
            if (typeof(T) == typeof(string))
            {
                // not sure why I had to do this
                if (!string.IsNullOrEmpty(value as string))
                {
                    return string.IsNullOrEmpty(value.ToString().Trim());
                }
                else
                {
                    return true;
                }
            }
            else if (typeof(T) == typeof(object))
            {
                // note: datatable columns are always seen as object at runtime with generic T regardless of how they are dynamically typed?
                if (value != null) {
                    return string.IsNullOrEmpty(value.ToString().Trim());
                }
            }
             
          return value == null || value.Equals(default(T));
      }
