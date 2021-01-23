    DateTime date;
    if (DateTime.TryParseExact(inputText, "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out date))
    {
       // Success
    }
