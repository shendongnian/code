            string input = @"I like C#. <code lang=""C#"">public static void main</code>THis is good language.";
            string rootedInput = String.Format("<root>{0}</root>", input);
            XDocument doc = XDocument.Parse(rootedInput);
            var nodes = doc.Root.DescendantNodes();
            StringBuilder sb = new StringBuilder();
            string nodeAsString = String.Empty;
            foreach (XNode node in nodes)
            {
                if (node.NodeType == XmlNodeType.Text)
                    nodeAsString = node.ToString().Replace(" ", "&nbsp;");
                else
                    nodeAsString = node.ToString();
                sb.Append(nodeAsString);
            }
            string newStr = sb.ToString();
