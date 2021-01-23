            HtmlDocument doc = new HtmlDocument();
            doc.Load(myHtmlFile); // load your file
            // select recursively all A elements declaring an HREF attribute.
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                node.ParentNode.ReplaceChild(doc.CreateTextNode(node.InnerText + " <" + node.GetAttributeValue("href", null) + ">"), node);
            }
            doc.Save(Console.Out); // output the new doc.
