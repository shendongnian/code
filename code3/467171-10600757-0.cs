    if (value != null)
    {
        if (value is double)
        {
            dt = DateTime.FromOADate((double)value);
        }
        else
        {
            DateTime.TryParse((string)value, out dt); //here you can try patterns of dd/mm/yyyy
        }
    }
