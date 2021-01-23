    public void GenerateRealTimeContent() 
    {
       var path = Server.MapPath("~/thefile.html");
       var dbContent = Database.GetContent(); // returns the <select> Options
       string[] lines = System.IO.File.ReadAllLines(path);
       StringBuilder sb = new StringBuilder();
       foreach (var line in lines) 
       {
         if (line == "CONTENT WHERE YOU WANT TO EDIT") 
         {
            SB.AppendLine(dbContent);
         }
       
         SB.AppendLine(line);
       }
      // code to write to your file
    }
