    string value = "13:00:36";
    DateTime dt;
    if (DateTime.TryParseExact(value, "HH:mm:ss", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
    {
        if (dt.TimeOfDay > DateTime.Now.TimeOfDay)
        {
            // grater than actual time 
        }
        else
        {
            // smaller than actual time
        }
    }
