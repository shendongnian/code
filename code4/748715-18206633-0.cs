            var doc = new XmlDocument();
            doc.LoadXml(@"<root>
    <nodeA>
        Hello
    </nodeA>
    <nodeA>
        <nodeB>
            node b Text
        </nodeB>
        <nodeImage>
            image.jpg
        </nodeImage>
    </nodeA>
    <nodeA>
        node a text
    </nodeA></root>");
            var xmlFrags = new List<string>();
            string xml = "<root>";
            bool bNewFragment = true;
            foreach (XmlNode nodeA in doc.SelectNodes("//root/nodeA")) {
                XmlNode nodeImage = nodeA.SelectSingleNode("nodeImage");
                if (nodeImage != null) {
                    xml += "<nodeA>";
                    var en = nodeA.GetEnumerator();
                    while (en.MoveNext()) {
                        XmlNode xn = (XmlNode)en.Current;
                        if (xn != nodeImage)
                            xml += xn.OuterXml;
                    }
                    xml += "</nodeA></root>";
                    xmlFrags.Add(xml);
                    xml = "<root><nodeA>" + nodeImage.OuterXml + "</nodeA></root>";
                    xmlFrags.Add(xml);
                    bNewFragment = true;
                }
                else {
                    if (bNewFragment) {
                        xml = "<root>";
                        bNewFragment = false;
                    }
                    xml += nodeA.OuterXml;
                }
            }
            if (!bNewFragment) {
                xml += "</root>";
                xmlFrags.Add(xml);
            }
            //Use the XML fragments as you like
            foreach (var xmlFrag in xmlFrags)
                Console.WriteLine(xmlFrag + Environment.NewLine);
