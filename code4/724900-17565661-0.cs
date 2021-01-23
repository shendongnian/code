     public static bool ValidateDate(object date)
     {
         try
         {
             if (Convert.ToDateTime(date) != null)
             {
                 return true;
             }
         }
         catch (Exception e)
         {
              return false;
         }
         return false;
     }
