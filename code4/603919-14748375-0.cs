    // if (node.NextSibling.Name.ToString() == "w:bookmarkEnd")
            {
                if (node.Attributes["w:name"].Value == bookmarkName)
                {
                        while (!node.NextSibling.Name.ToString().Equals("w:bookmarkEnd"))
                        {
                            node.ParentNode.RemoveChild(node.NextSibling);
                        }
    ......
