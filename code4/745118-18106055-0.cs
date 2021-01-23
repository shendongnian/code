    foreach (var item in Teamlist)
    {
        //Add own Name on Check
        // played.Add(item.Teamname); // <---- Move from here
    
        if (played.Contains(item.Teamname))
        {
        //Played against them already or is the same name as their own
        }
        else
        {
            //Add own Name on Check
            played.Add(item.Teamname); // <---- To here
            
            ...
