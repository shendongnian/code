    public void sendDays(List<Common.Day> days)
    {
        TimereportMappers mapper = new TimereportMappers();
    
        foreach (var day in days)
        {
            context.Days.AddObject(mapper.dayMap(day));
        }
                
        context.SaveChanges();
    }
