    _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    var dateTime = "10/03/2013 2:12:00 AM";
    DateTime universalFormatDateTime = Convert
                                      .ToDateTime(dateTime, new CultureInfo("en-GB"))
                                      .ToUniversalTime();
    if (_timeZoneInfo.IsInvalidTime(universalFormatDateTime))
        Console.WriteLine("Invalid DateTime");
    else
        Console.WriteLine("Valid DateTime");
