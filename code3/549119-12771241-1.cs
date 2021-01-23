            public static void Atdd(Control htmlOrWebCntrl, string prop, string value)
            {
                if (htmlOrWebCntrl.GetType().IsSubclassOf(typeof(WebControl)))
                {
                    WebControl wc = htmlOrWebCntrl as WebControl;
                    wc.Style.Add(prop, value);
                }
                else
                    if (htmlOrWebCntrl.GetType().IsSubclassOf(typeof(HtmlControl)))
                    {
                        HtmlControl HtmlCtrl = htmlOrWebCntrl as HtmlControl;
                        HtmlCtrl.Style.Add(prop, value);
                    }
            }
