        internal static void PrintAttributeValues(XDocument scr)
        {
            List<string> values = new List<string>();
            foreach (XElement elem in scr.Descendants("Signal"))
            {
                if (!values.Contains(elem.Attribute("UnityName").Value))
                {
                    values.Add(elem.Attribute("UnityName").Value);
                }
            }
            for (int j = 0; j < values.Count; j++)
            {
                Console.WriteLine(values[j]);
            }
        }
