    public void ErrorHandler(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Write(
            ((System.Web.HttpApplication)sender).Server.GetLastError().ToString()
        );
    }
