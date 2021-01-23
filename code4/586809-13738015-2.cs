     string value = string.Empty
     if (sdrDatanew.HasRows)
     {
         while (sdrDatanew.Read())
         {
              value= results[0].ToString();
         }
     }
