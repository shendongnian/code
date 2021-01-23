    Decimal i = stringName.ToType<Decimal>();
    public static T ToType<T>(this string value)
    {
         object parsedValue = default(T);
         try
         {
             parsedValue = Convert.ChangeType(value, typeof(T));
         }
         catch (InvalidCastException ice)
         {
             parsedValue = null;
         }
         catch (ArgumentException e)
         {
             parsedValue = null;
         }
         return (T)parsedValue;
    } 
