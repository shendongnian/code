            HtmlElementCollection forms = browser.Document.GetElementsByTagName("form");
            HtmlElement form = null;
            foreach (HtmlElement el in forms)
            {
                string name = el.GetAttribute("name");
                if (name == "DATA")
                {
                    form = el;
                    break;
                }
            }
