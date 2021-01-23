    DateTime feedate = new DateTime(2013, 09, 01);
    if (!rsData.IsDBNull(rsData.GetOrdinal("M_Start")) && (DateTime)rsData["M_Start"] < feedate)
    {
        // ...
    }
