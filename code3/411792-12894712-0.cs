        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //loaded the Yahoo login page
            if (browser.Url.AbsoluteUri.Contains(loginUrl))
            {
                if (browser.Document != null)
                {
                    //Find and fill the "username" textbox
                    HtmlElementCollection collection = browser.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element in collection)
                    {
                        string name = element.GetAttribute("id");
                        if (name == "username")
                        {
                            element.SetAttribute("value", _login);
                            break;
                        }
                    }
                    //Find and fill the "password" field
                    foreach (HtmlElement element in collection)
                    {
                        string name = element.GetAttribute("id");
                        if (name == "passwd")
                        {
                            element.SetAttribute("value", _password);
                            break;
                        }
                    }
                    //Submit the form
                    collection = browser.Document.GetElementsByTagName("button");
                    foreach (HtmlElement element in collection)
                    {
                        string name = element.GetAttribute("id");
                        if (name == ".save")
                        {
                            element.InvokeMember("click");
                            break;
                        }
                    }
                }
            }
        }
