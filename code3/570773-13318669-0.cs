    catch (Exception e)
    {
        if (e is FaultException && Regex.IsMatch(e.Message, "something"))
        {
            ....
        }
        else // all other exceptions
        {
            ....
        }
    }
