        public static void Set_Elements_Input(string element_name, string value)
        {
            if (_wb.InvokeRequired)
            {
                _wb.Invoke(new Action(() => { Set_Elements_Input(element_name, value); }));
            }
            else
            {
                HtmlElementCollection hec = _wb.Document.GetElementsByTagName("input");
                foreach (HtmlElement he in hec)
                {
                    if (he.GetAttribute("name") == element_name)
                    {
                        he.SetAttribute("value", value);
                    }
                }
            }
        }
