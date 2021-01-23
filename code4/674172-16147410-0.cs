     if (dt == null || dt.Rows.Count <= 0)
        return false;
    DateTime temp;
    if (dt.Rows[0].ItemArray.Any(r => DateTime.TryParse(r.ToString(), 
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, 
                                    out temp)))
    {
     //Column exists.
    }
