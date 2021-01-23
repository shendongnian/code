    using System.Globalization;
    using NodaTime;
    using NodaTime.Text;
    ...
    CultureInfo culture = CultureInfo.CreateSpecificCulture("fa-IR");
    CalendarSystem calendar = CalendarSystem.GetPersianCalendar();
    LocalDate template = new LocalDate(1, 1, 1, calendar);
    LocalDatePattern pattern = LocalDatePattern.Create("yyyy/M/d", culture, template);
    LocalDate result = pattern.Parse("1391/2/30").Value;
    
    // if you need a DateTime, then:
    DateTime dt = result.AtMidnight().ToDateTimeUnspecified();
