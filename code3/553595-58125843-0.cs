                    if (elm.GetAttribute("className").Contains("iceSelOneMnu"))
                    {
                        HtmlDocument doc = webBrowser1.Document;
                        elm.SetAttribute("value", "630676649");
                        elm.InvokeMember("onchange");
                    }
