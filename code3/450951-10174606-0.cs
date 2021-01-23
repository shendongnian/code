    string[] names1 = name1.ToLowerInvariant().Split(' ');
    string[] names2 = name2.ToLowerInvariant().Split(' ');
    if (names1.Length != names2.Length)
       return false; // unequal, different number of names
    foreach(name in names1)
       if (!names2.Contains(name))
           return false; // unequal, missing name
     
    return true; // equal
     
