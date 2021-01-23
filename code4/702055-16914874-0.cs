    if (DateTime.TryParseExact(txtdate.Text, format, CultureInfo.InvariantCulture,     DateTimeStyles.None, out userDob))
    {
        if (userDob < DateTime.Now )
        //TODO: Message will displayed
    }
    
