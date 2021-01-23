    LocalDateTimePattern dateTimePattern = LocalDateTimePattern.ExtendedIsoPattern;
    LocalDateTime date = dateTimePattern.Parse(dateText).Value;
    PeriodPattern pattern = PeriodPattern.RoundtripPattern;
    Period startTime = pattern.Parse(startTimeText).Value;
    Period endTime = pattern.Parse(endTimeText).Value;
   
    LocalDateTime startDateTime = date + startTime;
    LocalDateTime endDateTime = date + endTime;
