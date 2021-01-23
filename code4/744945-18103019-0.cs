    XDocument xDoc = XDocument.Load("C:\\test.xml");
            if (xDoc != null)
            {
                IEnumerable<XElement> xEle = xDoc.XPathSelectElements("//property");
                if (xEle != null)
                {
                    int iPass = 0;
                    foreach (XElement xE in xEle)
                    {
                        if (xE.Attribute("value") != null)
                        {
                            xE.Attribute("value").Value = "password" + iPass;
                            iPass++;
                        }
                    }
                    xDoc.Save("C:\\test.xml");
                }
            }
