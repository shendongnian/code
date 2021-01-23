    private void SetUserStartTimesUTC()
    {
        // clock would be a dependency; you *could* use SystemClock.Instance.Now,
        // but the code would be much more testable if you injected it.
        Instant now = clock.Now;
        // You can choose to use TZDB or the BCL time zones
        DateTimeZone zone = zoneProvider.FindSystemTimeZoneById(UserTimeZoneID);
        LocalDateTime userLocalNow = now.InZone(zone);
        LocalDate today = userLocalNow.Date;
        LocalDate startOfThisMonth = today.PlusDays(1 - today.Day);
        LocalDate startOfNextMonth = startOfThisMonth.PlusMonths(1);
        UserStartOfDayUTC = zone.AtStartOfDay(today);
        UserStartOfMonthUTC = zone.AtStartOfDay(startOfThisMonth);
        UserEndOfMonthUTC = zone.AtStartOfDay(startOfNextMonth);
    }
