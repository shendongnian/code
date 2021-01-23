            string[] elementNames = new string[]{ "<username>", "<password>"};
            foreach (string elementName in elementNames)
            {
                int startingIndex = xml.IndexOf(elementName);
                string value = xml.Substring(startingIndex + elementName.Length, xml.IndexOf(elementName.Insert(1, "/")) - (startingIndex + elementName.Length));
                Console.WriteLine(value);
            }
