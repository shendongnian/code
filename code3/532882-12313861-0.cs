            string input = @"
                <p xmlns=""http://www.w3.org/1999/xhtml"">
                    Text1
                    <span title=""instruction=componentpresentation,componentId=1234,componentTemplateId=1111"">
                        CPText2CP
                    </span>
                </p>";
            XDocument doc = XDocument.Parse(input);
            XNamespace ns = doc.Root.Name.Namespace;
            // I don't know what filtering criteria you want to use to 
            // identify the element that you wish to replace,
            // I just searched by "componentId=1234" inside title attribute
            XElement elToReplace = doc
                .Root
                .Descendants()
                .FirstOrDefault(el => 
                    el.Name == ns + "span" 
                    && el.Attribute("title").Value.Contains("componentId=1234"));
            
            XElement newEl = new XElement(ns + "componentpresentation");
            
            newEl.SetAttributeValue("componentID", "1234");
            newEl.SetAttributeValue("templateID", "1111");
            newEl.SetAttributeValue("dcpID", "dcp1111_1234");
            newEl.SetAttributeValue("dcplocation", 
                "/wip/data/pub60/dcp/txt/dcp1111_1234.txt");
            
            elToReplace.ReplaceWith(newEl);
