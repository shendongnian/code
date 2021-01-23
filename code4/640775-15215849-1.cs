    private static readonly ZoneLocalMappingResolver CustomResolver = 
        Resolvers.CreateMappingResolver(Resolvers.ReturnLater, AddGap);
    
    // SkippedTimeResolver which adds the length of the gap to the
    // local date and time.
    private static ZonedDateTime AddGap(LocalDateTime localDateTime,
                                        DateTimeZone zone,
                                        ZoneInterval intervalBefore,
                                        ZoneInterval intervalAfter)        
    {
        long afterMillis = intervalAfter.WallOffset.Milliseconds;
        long beforeMillis = intervalBefore.WallOffset.Milliseconds;
        Period gap = Period.FromMilliseconds(afterMillis - beforeMillis);
        return zone.AtStrictly(localDateTime + gap);
    }
