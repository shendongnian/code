    DateTime date;
    if (DateTime.TryParseExact(inputText, "MM/dd/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out date))
    {
       // Success
    }
