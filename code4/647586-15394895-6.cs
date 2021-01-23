     StringBuilder result = new StringBuilder();
     int i = 0;
     foreach (string line in File.ReadLines(Server.MapPath("~/App_Data/AirportCodes2.txt")))
     {
           if (line.Contains("Chicago"))
           { 
               i = i + 1;
               result.Append((string.Format("label{0}:{1}",i,line));
               result.Append("<br/>");
           }
    }
    lblAirportCodes = result.ToString();
