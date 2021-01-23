     public static class DateTimeHelpers
     {          
          static bool IsValidSqlDateTimeNative(string someval)
          {
               bool valid = false;
               DateTime testDate = DateTime.MinValue;
               System.Data.SqlTypes.SqlDateTime sdt;
               if (DateTime.TryParse(someval, out testDate))
               {
                   try
                   {
                       // take advantage of the native conversion
                       sdt = new System.Data.SqlTypes.SqlDateTime(testDate);
                       valid = true;
                   }
                   catch (System.Data.SqlTypes.SqlTypeException ex)
                   {
                       // no need to do anything, this is the expected out of range error
                   }
               }
               return valid;
           }
     }    
