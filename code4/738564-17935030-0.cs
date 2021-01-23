    Func<bool> action = () =>
            {
                HtmlElement head = webBrowser2.Document.GetElementsByTagName("head")[0];
                HtmlElement testScript = webBrowser2.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement) testScript.DomElement;
                element.text = "function TestClick() { $('" + testElement + "')[0].click(); }";
                head.AppendChild(testScript);
                webBrowser2.Document.InvokeScript("TestClick");
                string TestUrl = webBrowser2.Url.AbsoluteUri;
                if (TestUrl.Equals(expected)) {
                    HasSucceeded = 1;
                }
                else
                {
                    // No test
                }
                return HasSucceeded;
            };
            Task<bool> task = new Task<bool>(action);
            task.Start();
            task.Wait();
            return task.Result;
