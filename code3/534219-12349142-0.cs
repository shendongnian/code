    HtmlElementCollection tData = wb.Document.GetElementsByTagName("td");
                    foreach (HtmlElement td in tData)
                    {
                        string name = "";
                        if (td.GetAttribute("classname") == "name")
                        {
                            name = td.InnerText;
                        }
                    }
