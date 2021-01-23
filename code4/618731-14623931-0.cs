    foreach (var e in retreivedata())
    {
        e.CultSpecificRevisedData = null;
        e.CultSpecificPublishedData = null;
        if (!string.IsNullOrWhiteSpace(e.RevisedData))
        {
            e.CultSpecificRevisedData = ConvertToProfileSpecificFormat(
                Convert.ToDecimal(e.RevisedData),
                DecimalSeparator);
        }
        if (!string.IsNullOrWhitespace(e.PublishedData))
        {
            e.CultSpecificPublishedData = ConvertToProfileSpecificFormat(
                Convert.ToDecimal(e.PublishedData),
                DecimalSeparator);
        }
        switch (GetEnglishFrequencyBame(frequencyTypeMasId))
        {
            case FrequencyType.Monthly:
                var f = CultureInfo.CurrentCulture.DateTimeFormat;
                obj.CultSpecificPeriod = string.Format(
                    "{0}-{1}",
                    f.GetAbbreviatedMonthName(GetMonthNumber(e.Month)),
                    e.CalendarYear);
                break;
            case FrequencyType.Quarterly:            
                UserMessage = e.QuarterName;
                e.CultSpecificPeriod = string.Format(
                    "{0}-{1}",
                    e.QuarterName,
                    e.CalendarYear)
                break;
            case FrequencyType.BiAnnually:
                UserMessage = e.SemesterName;
                e.CultSpecificPeriod = string.Format(
                    "{0}-{1}",
                    e.SemesterName,
                    e.CalendarYear)
                break;
            default:
                obj.CultSpecificPeriod = e.CalendarYear.ToString();
        }
    }
