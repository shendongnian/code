    ulong count = 0;
    using (StreamReader sr = new StreamReader(Server.MapPath("03122013114450.txt"), true))
    {
       while (!sr.EndOfStream) {
           count++;
           String line = sr.ReadLine();
           if ((count % 2) == 0) {
               // do additional processing here
               // like insert row into database
           }
        }
    }
