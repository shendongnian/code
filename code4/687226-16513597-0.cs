    for (int i = 0; i < dv.Count; i++)
    {
        var value = dv[i][0].ToString();
        if (!string.IsNullOrEmpty(value)) 
        {
            var intValue = Convert.ToInt32(value);
            ...
        }
    }
