    //long way
    string sline=arQuery.GetType().Name + " ";
    foreach (PropertyInfo info in arQuery.GetType().GetProperties())
    {
       if (info.CanRead)
       {
          sline += info.Name+": "+info.GetValue(arQuery, null) + " ";
       }
    } 
    
    //using LINQ without the for loop
    sline += string.Join(" ", arQuery.GetType().GetProperties().Select(s=> ""+s.Name+": "+s.GetValue(arQuery, null)));
