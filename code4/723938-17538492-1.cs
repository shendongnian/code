        //add a reference to Microsoft.mshtml in solution explorer
        using mshtml;
        private SHDocVw.WebBrowser_V1 Web_V1;
        
        Form1_Load()
        {
            Web_V1 = (SHDocVw.WebBrowser_V1)webBrowser1.ActiveXInstance;
        }
        webBrowser1_Document_Complete()
        {
        if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                if (webBrowser1.Url.ToString() == "YourLoginSite.Com")
                {
                    try
                    {
                        HTMLDocument pass = new HTMLDocument();
                        pass = (HTMLDocument)Web_V1.Document;
                        HTMLInputElement passBox = (HTMLInputElement)pass.all.item("PassIDThatyoufoundinsource", 0);
                        passBox.value = "YourPassword";
                        HTMLDocument log = new HTMLDocument();
                        log = (HTMLDocument)Web_V1.Document;
                        HTMLInputElement logBox = (HTMLInputElement)log.all.item("loginidfrompagesource", 0);
                        logBox.value = "yourlogin";
                        HTMLInputElement submit = (HTMLInputElement)pass.all.item("SubmitButtonIDFromPageSource", 0);
                        submit.click();
                    }
                    catch { }
                }
            }
        }
