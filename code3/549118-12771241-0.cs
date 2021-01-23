          public static void Atdd(WebControl WebCntrl, string prop, string value)
            {
                if (WebCntrl.GetType().IsAssignableFrom(typeof(WebControl)))
                {
                    WebControl wc = WebCntrl as WebControl;
                    wc.Style.Add(prop, value);
                }
            }
