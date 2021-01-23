    XDocument doc = XDocument.Parse(INPUT_DATA);
    XElement handlers = doc.Element("handlers");
    IEnumerable<XElement> add = null;
    IEnumerable<XElement> pFind = null;
    if (handlers != null)
    {             
        add = handlers.Elements();
        if (add != null)
        {
            pFind = (from itm in add
                        where itm.Attribute("path") != null
                        && itm.Attribute("path").Value != null
                        && itm.Attribute("path").Value == "Reserved.ReportViewerWebControl.axd"
                        select itm);
            if(pFind != null)
                pFind.FirstOrDefault().Remove();
        }
    }
