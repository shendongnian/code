    using (var sr = new StreamReader(Server.MapPath("03122013114450.txt"), true))
    {
        var line = sr.ReadLine();
        while (line != null)
        {
            // Do stuff here. Add to the list, maybe?
    
            if (sr.ReadLine()!= null) //read the next line and ignore it.
                line = sr.ReadLine();
        }
    }
