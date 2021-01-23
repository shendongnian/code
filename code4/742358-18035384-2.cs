    DateTime dt;
    if (
        DateTime.TryParseExact(
            "08/03/2013", 
            "MM/dd/yyyy", 
            null, 
            System.Globalization.DateTimeStyles.None, 
            out dt
        )
    )
    {
        //Date in correct format
    }
