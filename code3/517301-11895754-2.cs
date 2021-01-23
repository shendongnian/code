    protected override void InitializeCulture()
    {
        // you have to call Request.Form, because at this point in the page life cycle, the page viewstate has not been loaded yet
        var culture = this.Request.Form["RadioButtonList1"];
    
        if (!string.IsNullOrWhiteSpace(culture))
        {
            // if the values of your list are culture specific (ie. en-US, es-MX, etc) you can uncomment the following line
            // this.Culture = culture;
            this.UICulture = culture;
            base.InitializeCulture();
        }
    }
