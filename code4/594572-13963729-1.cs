    // using System.Globalization;
    DateTime dt = DateTime.ParseExact(
        s,
        "yyyyMMddHHmm",
        CultureInfo.CurrentCulture.DateTimeFormat,
        DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
