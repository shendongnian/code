    _wb.Invoke(new Action(() => {
        HtmlElementCollection hec = _wb.Document.GetElementsByTagName("input");
        foreach (HtmlElement he in hec)
        {
            if (he.GetAttribute("name") == element_name)
            {
                he.SetAttribute("value", value);
            }
        }
     }
