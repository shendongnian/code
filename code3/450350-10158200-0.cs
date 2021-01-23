     object dobVal = null;
           while ((dobVal= reader.Read()) != null)
           {
               var storedDob = Convert.ToDateTime(dobVal.ToString());
    
               if(storedDob.Month == DateTime.Now.Month && storedDob.Day == DateTime.Now.Day)
               {
                   Session["Birthday"] = "Happy Birthday";
               }
    
           }
