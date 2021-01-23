     int i = 0;
     foreach (string line in File.ReadLines(Server.MapPath("~/App_Data/AirportCodes2.txt")))
     {
           if (line.Contains("Chicago"))
           { 
               i = i + 1;
               Response.Write(string.Format("label{0}:{1}",i,line));
           }
    }
