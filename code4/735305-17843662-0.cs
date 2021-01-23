    if (!File.Exists(set.cuLocation))
    {
        File.CreateText(set.cuLocation);
    }
    
    using(System.IO.StreamReader objReader = new System.IO.StreamReader(set.cuLocation))
    {
       set.currentUser = objReader.ReadLine();
    }
    if (set.currentUser == null)
    {
        File.WriteAllText(set.cuLocation, set.each2);
    }
