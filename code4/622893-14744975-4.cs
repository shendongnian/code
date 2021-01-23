    private static void ConvertToXml(Stream inputStream, Stream outputStream)
    {
        const int oneIndentLength = 4; // One level indentation - four spaces.
        var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true
            };
        using (var streamReader = new StreamReader(inputStream))
        using (var xmlWriter = XmlWriter.Create(outputStream, xmlWriterSettings))
        {
            int previousIndent = -1; // There is no previous indent.
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var indent = line.TakeWhile(ch => ch == ' ').Count();
                indent /= oneIndentLength;
                var elementName = line.Trim();
                if (indent <= previousIndent)
                {
                    // The indent is the same or is less than previous one - write end for previous element.
                    xmlWriter.WriteEndElement();
                    var indentDelta = previousIndent - indent;
                    for (int i = 0; i < indentDelta; i++)
                    {
                        // Return: leave the node.
                        xmlWriter.WriteEndElement();
                    }
                }
                xmlWriter.WriteStartElement(elementName);
                // Save the indent of the previous line.
                previousIndent = indent;
            }
        }
    }
    
