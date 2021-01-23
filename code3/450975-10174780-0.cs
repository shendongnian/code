    DateTime dt;
    if (DateTime.TryParse("4/2/2012 12:00 AM",dt))
    {
      String Result = "";
      if (DateTime.Date > DateTime.MinValue)
        Result = dateTime.ToString("d/M/YYYY");
      if (DateTime.TimeOfDay > TimeSpan.MinValue)
        Result += dateTime.ToString("hh:mm tt");
    }
