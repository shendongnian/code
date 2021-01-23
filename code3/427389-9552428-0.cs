        void SetText(string attribute, string attName, string value)
        {
            HtmlElementCollection tagsCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement currentTag in tagsCollection)
            {
                if (currentTag.GetAttribute(attribute).Equals(attName))
                    currentTag.SetAttribute("value", value);
            }
        }
        void CheckBox(string attribute, string attName, string value)
        {
            // Get a collection of all the tags with name "input";
            HtmlElementCollection tagsCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement currentTag in tagsCollection)
            {
                if (currentTag.GetAttribute(attribute).Equals(attName))
                    currentTag.SetAttribute("checked", value);
            }
        }
        void ClickButton(string attribute, string attName)
        {
            webBrowser1.Document.GetElementsByTagName("input");
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("button");
            foreach (HtmlElement element in col)
            {
                if (element.GetAttribute(attribute).Equals(attName))
                {
                    element.InvokeMember("click");
                }
            }
        }
