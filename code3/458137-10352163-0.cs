    public class Test
    {
        private DateTime dateDeliveryRequestField;
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DateDeliveryRequest { get { return this.dateDeliveryRequestField; } set { this.dateDeliveryRequestField = value; } }
    }
    private string SerializeAnObject(object obj)
    {
        System.Xml.XmlDocument doc = new XmlDocument();
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        try
        {
           serializer.Serialize(stream, obj);
           stream.Position = 0;
           doc.Load(stream);
           return doc.InnerXml;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    Test n = new Test();
    n.DateDeliveryRequest = DateTime.Parse("2012-10-07");
    string result = SerializeAnObject(n);
