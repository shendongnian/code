    var start = new NodaTime.LocalDateTime(s.Year, s.Month, s.Day, s.Hour, s.Minute);
    var end = new NodaTime.LocalDateTime(e.Year, e.Month, e.Day, e.Hour, e.Minute);
    
    NodaTime.Period periodInclusive = NodaTime.Period.Between(start, end.PlusDays(1), NodaTime.PeriodUnits.AllDateUnits);
    NodaTime.Period period =  NodaTime.Period.Between(start, end, NodaTime.PeriodUnits.AllDateUnits);
    bool isInclusivePeriod = periodInclusive.Days + periodInclusive.Weeks + periodInclusive.Months + periodInclusive.Years < 
    						 period.Days + period.Weeks + period.Months + period.Years;
    
    period = isInclusivePeriod ? periodInclusive : period;
    // do stuff with period here....
