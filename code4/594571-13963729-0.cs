    DateTime dt = DateTime.ParseExact(
        s,
        "yyyyMMddHHmm",
        System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat,
        System.Globalization.DateTimeStyles.AssumeUniversal);
