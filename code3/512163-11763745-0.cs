    // Simple Base64 conversion (using UTF8 for simplicity)
    // ========
    // Assume [sequences] is variable of type [Entities.Application]
    string xmlString;
    var xs = new XmlSerializer(typeof(Entities.Application));
    using (var sw = new StringWriter())
    {
        xs.Serialize(sw, sequences);
        xmlString = sw.ToString();
    }
    string encoded = System.Convert.ToBase64String(
                        System.Text.Encoding.UTF8.GetBytes(xmlString));
    // Converting encoded [Entities.Application] to decoded XML string,
    // using some of your code for consistency.
    string encoded;
    using (TextReader textReader = new StreamReader(XMLFile))
    {
        encoded = textReader.ReadToEnd();
        textReader.Close();
    }
    string decoded = System.Text.Encoding.UTF8.GetString(
                        System.Convert.FromBase64String(encoded));
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Entities.Application));
    using (var sr = new StringReader(decoded))
    {
        sequences = (Entities.Application)xmlSerializer.Deserialize(sr);
    }
    // Inserting Base64 in XmlElement
    // ========
    // Optional: the old MSXML.DOMDocument had nodeTypedValue, and you
    // can set the same attributes if you are going to use DOMDocument, although
    // it is still a good idea to tag the element so you know its datatype.
    node.SetAttribute("xmlns:dt", "urn:schemas-microsoft-com:datatypes");
    node.SetAttribute("dt", "urn:schemas-microsoft-com:datatypes", "bin.base64");
    // Assume serialized data has already been encoded as shown above
    var elem = node.AppendChild(xmlDoc.CreateTextNode(encoded));
