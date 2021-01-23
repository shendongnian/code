     DateTime DateT = new DateTime.Now; 
     string Myvariable = "13:00:36";
     // we need to get the time string as a DateTime
     DateTime parsedTime = DateTime.ParseExact(
        Myvariable, 
        "HH:mm:ss", 
        CultureInfo.InvariantCulture);
