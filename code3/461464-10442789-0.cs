    public class Foo<T> : IXmlSerializable {
        public T Value { get; set; }
        XmlSchema IXmlSerializable.GetSchema() {
            return GetSchema();
        }
        protected virtual XmlSchema GetSchema() {
            return null;
        }
        public virtual void ReadXml(XmlReader reader) {
            reader.ReadStartElement();
            var xmlSerializer = new XmlSerializer(typeof(T));
            Value = (T)xmlSerializer.Deserialize(reader);
            reader.ReadEndElement();
        }
        public virtual void WriteXml(XmlWriter writer) {
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(writer, Value);
        }
    }
