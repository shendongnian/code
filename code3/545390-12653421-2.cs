    ...
    for (int i = 0; i < stringArray.Count() - 1; i++)
    {
        if(props[i].GetValue(m) is DateTime)
        {
            props[i].SetValue(m, DateTime.Parse(stringArray[i]));
        }
        else
        {
            if(props[i].GetValue(m) is bool)
            {
                props[i].SetValue(m, stringArray[i].Equals("true", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                 props[i].SetValue(m, stringArray[i]);
            }
        }
    }
    ...
