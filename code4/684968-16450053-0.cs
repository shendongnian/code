    if (Contact._contactInfo && 
        String.Equals(Contact._contactInfo.City.ToLower(), city,
                      StringComparison.CurrentCulture))
    {
        ContactsByCity.Add(Contact);
    }
