    object val = Key.GetValue("EnableOplocks");
    if (val == null)
    {
        // ...
    }
    else
    {
        string strVal = val.ToString();
        if (strVal == "1")
        {
            // ...
        }
    }
