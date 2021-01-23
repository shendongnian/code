        private XElement GetElementFromXPath(XDocument xDoc, string xPath)
        {
            string[] nodes = xPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            XContainer xe = xDoc.Root;
            for (int i = 1; i < nodes.Length; i++)
            {
                string[] chunks = nodes[i].Split(new char[] { '[', ']' });
                int index = 0;
                if (Int32.TryParse(chunks[1], out index))
                    xe = xe.Elements(chunks[0]).ElementAt(index - 1);
            }
            return (XElement)xe;
        }
