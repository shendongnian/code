    public void HtmlCapture2()
            {
                try
                {
                    if (web == null)
                        web = InitWebBrowser();
    
                    web.Navigate(_navigateURL);
    
                    try
                    {
                        while (_pageReady == false) // YEAH!!!!!! IT IS WORKING!!!!
                        {
                            System.Windows.Forms.Application.DoEvents();
                         }
                        //Thread.Sleep(WaitForWebsite); --- It works but....
                        //while (web.ReadyState != WebBrowserReadyState.Complete) --- it gives an ERROR
                        //    System.Windows.Forms.Application.DoEvents();
                    }
                    catch (Exception)
                    {
                    }
                }
                catch (Exception)
                {
                }
            }
