      public static bool IsPropertyExist(dynamic dynamicObj, string property)
           {
               try
               {
                   var value=dynamicObj[property].Value;
                   return true;
               }
               catch (RuntimeBinderException)
               {
    
                   return false;
               }
           
           }
