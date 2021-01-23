    [WebMethod]
    public SendCodeResult SendCode(string userId, string barCode)
    {
        SendCodeResult scr = new SendCodeResult();
        scr.code = "";
        return scr;
    }
