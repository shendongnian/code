    TimeSpan time24 = new TimeSpan(24, 0, 0);
    TimeSpan time18 = new TimeSpan(18, 0, 0);    
    
    var clientdtminus24 = clientDateTime - time24;
    // first get today's sleeping hours
    List<Model.Sleep> sleeps = context.Sleeps.Where(
        o => (clientdtminus24 < o.ClientDateTimeStamp) && 
              o.ClientDateTimeStamp.TimeOfDay > time18 && 
              clientDateTime.TimeOfDay < time18 && 
              o.UserID == userid).ToList();
