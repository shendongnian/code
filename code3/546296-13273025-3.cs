    [WebMethod]
    public SendCodeResponse SendCode(string userId, string barCode)
    {
        SendCodeResponse scr = new SendCodeResponse();
        scr.code = "";
        return scr;
    }
