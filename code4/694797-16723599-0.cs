    bool validDate = false;
    DateTime dt = new DateTime();
    try
    {
        dt = Convert.ToDateTime(modifiedSince);
        validDate = true;
    }
    catch(FormatException) { string message = "Not a valid date..."; }
    
    if (validDate)
    {
        //Do whatever else you need to do with the validated date.
    }
