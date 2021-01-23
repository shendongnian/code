    void OpenUrl(Url url)
    {
       try
       {
           var webBrowser = GetWebBrowser(tabControl.SelectedTab);
           webBrowser.OpenUrl(url);
       }
       catch(SpecificException ex)
       {
           MyApplication.HandleException(ex);
       }
    }
