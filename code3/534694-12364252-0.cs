    HtmlElementCollection tData = wb.Document.GetElementsByTagName("div");
                foreach (HtmlElement td in tData)
                {
                    string name = "";
                    if (td.GetAttribute("classname") == "blink")
                    {
                        name = td.InnerText;
                    }
                }
