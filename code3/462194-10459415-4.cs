    String valuesarr = String.Empty;
    for (int i = 0; i < dt.Rows.Count - 1; i++)
    {
        List<object> lst = dt.Rows[i].ItemArray.ToList();
        foreach (Object s in lst)
        {
            valuesarr += s.ToString();
        }
        if (String.IsNullOrEmpty(valuesarr))  
            dt.Rows.RemoveAt(i);
     }
