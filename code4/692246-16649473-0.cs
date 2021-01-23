          XmlDocument document = new XmlDocument();
            document.Load(@"c:\users\saravanan\documents\visual studio 2010\Projects\test\test\XMLFile1.xml");
            XmlNodeList itemNodes = document.SelectNodes("//item");
            foreach (XmlElement node in itemNodes)
            {
                if (node.Attributes.Count > 0)
                {
                    if (node.HasAttribute("id"))
                    {
                        Console.Write(node.Attributes["id"]);
                    }
                }
            }
            var itemNodeswithAttribute = document.SelectNodes("//item[href=toc.ncx]");
            itemNodeswithAttribute = document.SelectNodes("//item[@href='toc.ncx']");
