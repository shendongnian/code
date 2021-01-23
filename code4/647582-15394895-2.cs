     foreach (string line in File.ReadLines(Server.MapPath("~/App_Data/AirportCodes2.txt")))
     {
           if (line.Contains("Chicago"))
           {
               Response.Write(line);
           }
    }
