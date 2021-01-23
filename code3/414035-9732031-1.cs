    protected override void InitializeCulture()
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = culture;
        base.InitializeCulture();
    }
