    public void IsMobileBrowser()
    {
        String labelText = "";
        System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
        if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
        {
            labelText = "Browser is a mobile device.";
        }
        else
        {
            labelText = "Browser is not a mobile device.";
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('"+ labelText + "');", true);
    }
