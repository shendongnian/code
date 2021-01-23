    public bool IsValidMailAddress(string s)
    {
        try
        {
            MailAddress m = new MailAddress(s);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
