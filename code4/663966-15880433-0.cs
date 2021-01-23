    //I added this method after I tried serialize directly to no avail
        public String SerializeToXml()
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            new XmlSerializer(typeof(PaymentNotificationResponse)).Serialize(ms, this, ns);
            XmlTextWriter textWriter = new XmlTextWriter(ms, Encoding.UTF8);
            ms = (System.IO.MemoryStream)textWriter.BaseStream;
            return new UTF8Encoding().GetString(ms.ToArray());
        }
