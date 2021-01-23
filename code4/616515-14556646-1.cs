    for (int i = 0; i < doc.Length; i++)
    {
        name = doc[i].ToString();
    
        if(name != null && name.Length >= 12)
        {    
            name = name.Substring(12);    
            break;
        }
    }
