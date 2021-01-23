    public bool Validate(Stuff stuff, out string message)
    {
        message = "Invalid Date(s): ";
        return ValidateDates(ref message, stuff.Date1, stuff.Date2, stuff.Date3, stuff.Date4);
    }
    public bool ValidateDate(ref string message, params string[] dates)
    {
        bool rv = true;
        for (int i = 0; i < dates.Length; i++)
        {
            if (![validate DateTime as above])
            {
                message += i + " "; // add the failed index to the message
                rv = false;
            }
        }
        return rv;
    }
