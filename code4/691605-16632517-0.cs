    foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("TEXTAREA"))
    {
				
        HTMLTextAreaElement textarea = (HTMLTextAreaElement)el.DomElement;
        xWriter.WriteStartElement("Item");
        xWriter.WriteElementString("GUID", el.Id);
				
        foreach (var attribute in textarea.attributes)
        {
             String name = attribute.name;
             String value = attribute.value;
             xWriter.WriteElementString(name, value);
        }
				
        xWriter.WriteEndElement();
    }
