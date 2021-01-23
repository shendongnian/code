    public class StackOverflow_11471676
    {
        public class UpdateOrderStatus
        {
            public int Action { get; set; }
            public ValueInfo Value { get; set; }
        }
        [XmlType(TypeName = "Shipment")]
        public class ShipmentInfo
        {
            public string Header { get; set; }
            public string Body { get; set; }
        }
        public class ValueInfo : IXmlSerializable
        {
            public ShipmentInfo Shipment { get; set; }
            private XmlSerializer shipmentInfoSerializer = new XmlSerializer(typeof(ShipmentInfo));
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(XmlReader reader)
            {
                using (MemoryStream ms = new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        reader.ReadContentAsString())))
                {
                    Shipment = (ShipmentInfo)this.shipmentInfoSerializer.Deserialize(ms);
                }
            }
            public void WriteXml(XmlWriter writer)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (XmlWriter innerWriter = XmlWriter.Create(ms, new XmlWriterSettings { OmitXmlDeclaration = true }))
                    {
                        shipmentInfoSerializer.Serialize(innerWriter, this.Shipment);
                        innerWriter.Flush();
                        writer.WriteCData(Encoding.UTF8.GetString(ms.ToArray()));
                    }
                }
            }
        }
        public static void Test()
        {
            UpdateOrderStatus obj = new UpdateOrderStatus
            {
                Action = 1,
                Value = new ValueInfo
                {
                    Shipment = new ShipmentInfo
                    {
                        Header = "Shipment header",
                        Body = "Shipment body"
                    }
                }
            };
            XmlSerializer xs = new XmlSerializer(typeof(UpdateOrderStatus));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, obj);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
