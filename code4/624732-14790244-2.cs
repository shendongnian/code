    public static CultureInfo TryGetCultureByName(string name)
    {
       try
       {
         return new CultureInfo(name);
       }
       catch(CultureNotFoundException)//Only catching CultureNotFoundException
       {
         return null;
       }
    }
