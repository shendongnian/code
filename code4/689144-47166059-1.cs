I've added a couple of re-factorings:
 1. DBNull is not seen as isnullorempty so added the (value as string)
 2. Passing a datatable row[column] that was created dynamically at runtime (like: row["PropertyName"]) will not see this as a string with typeof(T) due to the fact that the column type base is object. So added an extra check for typeof(object) and if not null test that the ToString() is empty value. I haven't tested this fully so may not work for all types of data columns.
      public static bool CheckNullOrEmpty<T>(T value)
      {
            // note: this does not see DBNull as isnullorempty.  
            if (typeof(T) == typeof(string))
            {
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
