    
        XmlDocument doc = new XmlDocument();
        doc.InnerXml = xml;
        XmlElement rootElement = doc.DocumentElement as XmlElement;
        XmlNamespaceManager xns = new XmlNamespaceManager(doc.NameTable);
        xns.AddNamespace("ns", "http://tempuri.org/SplitterLayoutDataSet.xsd");
        if (rootElement != null)
        {
            foreach (KeyValuePair<Control, object> key in SaveLayoutControls)
            {
                Control c = key.Key;
                XmlElement el = rootElement.SelectSingleNode("ns:SplitterLayout", xns) as XmlElement;
                if (el != null)
                {
                    if (c is GridControl)
                        SetGridLayout(el, c as GridControl);
                    else if (c is SplitContainerControl)
                        SetSplitContainerLayout(el, c as SplitContainerControl);
                    else if (c is TreeList)
                        SetTreeListLayout(el, c as TreeList);
                    else if (c is CollapsibleSplitter)
                        SetCollapsibleSplitterLayout(el, c as CollapsibleSplitter);
                    else if (c is Splitter)
                        SetSplitterLayout(el, c as Splitter);
                }
            }
        }
