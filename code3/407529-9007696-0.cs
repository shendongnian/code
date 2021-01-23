    public LocationTimesMap()
    {
        Table("Location_Times");
        Id(x => x.ID);
        Map(x => x.earlyHoursStart).Column("EHStart");
        Map(x => x.earlyHoursEnd).Column("EHEnd");
        Map(x => x.earlyHoursPrice).Column("EHSell");
        References(x => x.Location).Column("LID"); 
    }
