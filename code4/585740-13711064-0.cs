        // use a XStreamingElement for writing
        var st = new XStreamingElement("root"); 
        using(var xr = new XmlTextReader(stream))
        {
            while (xr.Read())
            {
                // whatever you're interested in
                if (xr.NodeType == XmlNodeType.Element) 
                {
                    var node = XNode.ReadFrom(xr) as XElement;
                    if (node != null)
                    {
                        ProcessNode(node);
                        st.Add(node);
                    }
                }
                
            }
        }
        st.Save(outstream); // or st.WriteTo(xmlwriter);
