    foreach( S s1 in S_list)
    {
        boolean foundInEx = false;
        foreach(Ex li in ex)  // 
        {
            if (s1.Name.Equals(li.ToString()))
            {
                foundInEx = true;
                break;
            }
        }
        if(!foundInEx) 
        {
            ex.Add(s1.Name); //only executed when there is no such element in ex
        }
    }
