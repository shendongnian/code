    public bool TryPrint()
    {
        try
        {
            _printer.Print(_text);
            return true;
        }
        catch (Exception ex)
        {
            // of course, log exception
            return false;
        }           
    }
