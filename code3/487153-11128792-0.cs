    [WebMethod]
    public static AjaxReturnObject SubmitWager(string token, string track, string race,   string amount, string pool, string runners)
    {
    try
    {
        var serviceReturn = Services.Account.SubmitWager("", track, race, pool, amount, runners);
        return new AjaxReturnObject(serviceReturn.AccountToken, serviceReturn.Payload);
    }
    catch (CustomServiceException<string> e)
    {
        return new AjaxReturnObject(0, e.Message();
    }
    }
