    try
    {    }
    catch (Exception e)
    {
        EventLog.WriteEntry(this.GetType().FullName, " error[.] " + e.Message);
    }
