    private static Country country;
    public static CountryProvider Instance
    {
       get
       {
          if(country == null)
          {
             country = new Country();
          }
          return country;
       }
    }
