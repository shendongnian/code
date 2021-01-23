    protected void Page_PreInit(object sender, EventArgs e)
    {
        switch (Request.QueryString["mode"])
        {
            case "receipts.com":
                Page.Theme = "DefaultTheme";
                break;
            case "business.receipts.com":
                Page.Theme = "BusinessTheme";
                break;
        }
    }
