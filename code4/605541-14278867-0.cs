    protected override void InitializeCulture()
    {
        string language = Session["language"].ToString(); // e.g. en-GB
        System.Threading.Thread.CurrentThread.CurrentUICulture =
            System.Globalization.CultureInfo.GetCultureInfo(language);
    }
