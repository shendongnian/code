    public JsonResult GetJsonAfmeldingen()
    {
        if (Functions.HasLoginCookie())
        {
            //This one is probably not filled.
            if (Models.Taken.ActID > 0)
            {
