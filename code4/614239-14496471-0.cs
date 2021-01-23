    string url = string.Empty;
    try
    {
        DdeClient oDde = new DdeClient("IExplore", "WWW_GetWindowInfo");
        try
        {
            oDde.Connect();
            url = oDde.Request("1", int.MaxValue);
            oDde.Disconnect();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }
