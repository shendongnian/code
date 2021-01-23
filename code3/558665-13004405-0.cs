        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Parse("<root><object type=\"node\" ><property name=\"id\" value=\"1\" /><property name=\"name\" value=\"ossvc06_node1\" /></object><object type=\"node\" ><property name=\"id\" value=\"2\" /><property name=\"name\" value=\"ossvc06_node2\" /></object></root>");
            var nodes = xdoc.Descendants("object").Where(node => node.Attribute("type").Value == "node").ToList();
            foreach (XElement nodelement in nodes)
            {
                List<XElement> nodeles = nodelement.Elements().ToList();
                foreach (var node in nodeles)
                    Console.WriteLine(node);
            }
        }
