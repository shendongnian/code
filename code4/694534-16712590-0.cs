    try
       {
         string from = Server.MapPath(MainRoot + values[1].ToString());
         string to = Server.MapPath(MainRoot + newFolderPath);
         If(!Directory.Exists(from) || !Directory.Exists(to))
         {
           Throw new Exception("One of the directories doesn't exist");
         }
         Directory.Move(from, to); 
       }  
       Catch(Exception ex)
       {
         File.WriteAllText("Error.txt", ex.Message);
       }
