    public XElement Post()
        {
            //...Same as it was in the question, just the last line that changed.
            var pnr = CreatePaymentNotificationFromString(str);
            return XDocument.Parse(pnr.SerializeToXml()).Root;
        }
