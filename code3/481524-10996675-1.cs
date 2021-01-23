     void AddDispatcher(AxWebBrowser browser)
            {
                IHTMLDocument2 doc = (IHTMLDocument2)browser.Document;
                foreach (IHTMLElement VARIABLE in doc.all)
                {
                    //find right element
                    if (VARIABLE.title == "the name")
                    {
                        // attach here               
                        DispatcherClass dp = new DispatcherClass();
                        VARIABLE.onclick = dp;
                    }
                        
                }
             }
