    Decimal i = stringName.ToType<Decimal>();
    public static T ToType<T>(this string value)
    {
         object parsedValue = default(T);
         try
         {
             parsedValue = Convert.ChangeType(value, typeof(T));
         }
         catch (InvalidCastException)
         {
             parsedValue = null;
         }
         catch (ArgumentException)
         {
             parsedValue = null;
         }
         return (T)parsedValue;
    } 
