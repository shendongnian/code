            HtmlDocument doc = webBrowser1.Document;
            HtmlElementCollection divs = doc.GetElementsByTagName("div");
            foreach (HtmlElement div in divs)
            {
                try
                {
                    var info = div.DomElement;
                    PropertyInfo[] pi = info.GetType().GetProperties();
                    string strClass = pi[0].GetValue(div.DomElement).ToString();
                    if (strClass == "cls")
                    {
                    		//DoStuff
                    }
                }
                catch
                {
                
                }
            }
