    foreach (int b in B)
       {
        S=  A.Where(n => n % 4 == b).ToArray();
        foreach (int s in S)
        {
            newlist.Add(s); 
        }
       }
    newlist.Distinct().ToArray();
