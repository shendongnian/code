    for (int i = 0; i < doc.Length; i++)
    {
        name = doc[i].ToString();
    
        try
        {
            if (!string.IsNotNullOrEmpty(name))
            {
                name=name.ToString().Substring(12);
            }
        }
        catch{ } 
    }
