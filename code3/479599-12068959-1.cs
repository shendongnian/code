    /* The event handler*/
    private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
            {
                var webbrowser = (WebBrowser)sender;
                e.Cancel = true;
                OpenWebsite(webbrowser.StatusText.ToString());
                webbrowser = null;
            }
    
    /* The function call*/
    public static void OpenWebsite(string url)
            {
                Process.Start(GetDefaultBrowserPath(), url);
            }
