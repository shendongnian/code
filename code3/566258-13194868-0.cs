    public override bool Parse(string input, out Envelope envelope)
    {
        XmlDocument doc = new XmlDocument();
        //Load XML from the file into XmlDocument object
        doc.LoadXml(input);
        envelope = new Envelope ();
        XmlNode root = doc.DocumentElement;
        XmlNode MsgEnvroot = doc.DocumentElement.SelectSingleNode("MsgEnvelope");
        XmlNode MsgBodyroot = doc.DocumentElement.SelectSingleNode("MsgBody");
        XmlNodeList nodeList = root.SelectNodes("MsgEnvelope");
        foreach (XmlNode node in nodeList)
        {
            envelope.Priority = node["Priority"].InnerText;
            envelope.RecipientPIMA = node["RecipientPimaAddress"].InnerText;
            envelope.SenderPIMA = node["SenderPimaAddress"].InnerText;
            envelope.EnvelopeDateTime = node["GMT"].InnerText;
        }
        envelope.MsgEnvString = MsgEnvroot.InnerText;
        envelope.MsgBodyString = MsgBodyroot.InnerText;
        return true;
    }
