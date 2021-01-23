    string input = "2012-11-24 15:35:18";
    DateTime dateTime;
    if (DateTime.TryParse(input, out dateTime))
    {
        ulong epoch = (dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
    }
