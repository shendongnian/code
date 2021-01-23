    DateTime dt;
    if (DateTime.TryParseExact("01/01/2001", @"dd\/MM\/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
    {
        //Date in correct format
    }
