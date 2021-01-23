    foreach (DataRow dr in Second.Rows)
    {
        List<Object> l = new List<Object>();
    
        foreach (DataColumn dc in secondcolumns) l.Add(dr[dc]);
    
        if (First.Rows.Find(l.ToArray()) == null) //NOT FOUND
        {
            table.Rows.Add(l.ToArray());
        }
    }
    foreach (DataRow dr in First.Rows)
    {
        List<Object> l = new List<Object>();
    
        foreach (DataColumn dc in firstcolumns) l.Add(dr[dc]);
    
        if (Second.Rows.Find(l.ToArray()) == null) //NOT FOUND
        {
            table.Rows.Add(l.ToArray());
        }
    }
