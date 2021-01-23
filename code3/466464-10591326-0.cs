    public ISessionFactory BuildSessionFactory()
    {
       if (Today == DayOfWeek.Friday)
       {
          return new BeerOClockSessionFactory();
       }
       return SomeOtherSessionFactory();
    }
