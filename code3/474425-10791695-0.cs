      foreach(DataRow dr in table)
      {
         if (string.String.IsNullOrEmpty(dr["MembershipNumber"]))
         {
             Console.Write("This row is empty");
         } 
         else
         {
             Console.Write("This row is not empty there is more processing to do.");
         }
      }
