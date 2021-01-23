    Try this 
    
        Try
        {
        var fileName = HttpContext.ApplicationInstance.Server.MapPath("~/App_Data/emails.txt");
         if(System.IO.File.Exists(fileName ))                  
        {
           FileStream fs = new FileStream(fileName, FileMode.Append);
                           StreamWriter sw = new StreamWriter(fs);
                           sw.WriteLine(String.Format("{0}\t{1}", email, name));
                           sw.Flush();
                           sw.Close();
         }                  fs.Close();
        }
        else
        {
           throw error here
        }
        Catch()
        {
        
        }
