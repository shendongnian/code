    public bool checkContentsStartsWith(Worksheet sht, string address, string cellValue)
    {
       Range tempRange = sht.Range[address];
      return cellValue.StartsWith(tempRange.Value2);
    }
    
    public string getVersion(Worksheet sht)
    {
        for (int j = 1; j < 4;j++)
        {
            for (int i = 24; i > 0; i--)
            {
                if (checkContentsStartsWith(sht, "A" + j.ToString(), "Changes for Version " + i))
                {
                    return i;
                }
            }
        }
    }
