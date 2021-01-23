    public bool IsValidEmailAddress(string emailAddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailAddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
