    if (!context.PostalCodes.Any())
    {
        IEnumerable<PostalCode> postalCodes = ReadPostalCodes();
        foreach(var postalCode in postalCodes)
        {
            context.PostalCodes.Add(postalCode);
        }
        context.SaveChanges();
    }
