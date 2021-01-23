     public string NullableObjectToString(object obj)
     {
          try
          {
              if (obj == null)
                  return "";
              return (obj ?? string.Empty).ToString();
          }
          catch (Exception)
          {
              return "";
          }
      }
