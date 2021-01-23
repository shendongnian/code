    string[] names = new string[dt.Rows.Count];
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	names[i] = dt.Rows[i]["E"].ToString();
    }
    Array.Sort(names);
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	dt.Rows[i]["E"] = names[i];
    }
