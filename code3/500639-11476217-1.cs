        // Test function
        const string t = @"<UpdateOrderStatus> 
            <Action>2</Action> 
                <Value> 
                    <![CDATA[<ShipmentInfo>
          <Package>packageInfo</Package>
          <Header>headerInfo</Header>
        </ShipmentInfo>]]>
                 </Value>
        </UpdateOrderStatus>";
        static void Test1()
        {
            UpdateOrderStatus os = Deserialize(t);
            String t2 = XmlUtil.Serialize(os);
        }
        // Helper functions
        static UpdateOrderStatus Deserialize(String str)
        {
            UpdateOrderStatus os = XmlUtil.DeserializeString<UpdateOrderStatus>(str);
            os.Shipment = XmlUtil.DeserializeString<ShipmentInfo>(os.Value.InnerText);
            return os;
        }
        public static class XmlUtil
        {
            public static String Serialize<T>(T o)
            {
                XmlSerializer s = new XmlSerializer(typeof(T)); //, overrides);
                //StringBuilder builder = new StringBuilder();
                MemoryStream ms = new MemoryStream();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(ms, settings))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, String.Empty);
                    s.Serialize(xmlWriter, o, ns);
                }
                Byte[] bytes = ms.ToArray();
                // discard the BOM part
                Int32 idx = settings.Encoding.GetPreamble().Length;
                return Encoding.UTF8.GetString(bytes, idx, bytes.Length - idx);
            }
            public static T DeserializeString<T>(String content)
            {
                using (TextReader reader = new StringReader(content))
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    return (T)s.Deserialize(reader);
                }
            }
            
            ...
        }
