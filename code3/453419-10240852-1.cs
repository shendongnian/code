    public class ConcreteXmlObjectSerializer : XmlObjectSerializer
    {
        readonly Type objectType;
        XmlSerializer serializer;
        public ConcreteXmlObjectSerializer(Type objectType)
            : this(objectType, null, null)
        {
        }
        public ConcreteXmlObjectSerializer(Type objectType, string wrapperName, string wrapperNamespace)
        {
            if (objectType == null)
                throw new ArgumentNullException("objectType");
            if ((wrapperName == null) != (wrapperNamespace == null))
                throw new ArgumentException("wrapperName and wrapperNamespace must be either both null or both non-null.");
            if (wrapperName == string.Empty)
                throw new ArgumentException("Cannot be the empty string.", "wrapperName");
            this.objectType = objectType;
            if (wrapperName != null)
            {
                XmlRootAttribute root = new XmlRootAttribute(wrapperName);
                root.Namespace = wrapperNamespace;
                this.serializer = new XmlSerializer(objectType, root);
            }
            else
                this.serializer = new XmlSerializer(objectType);
        }
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            throw new NotImplementedException();
        }
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            Debug.Assert(serializer != null);
            if (reader == null) throw new ArgumentNullException("reader");
            if (!verifyObjectName)
                throw new NotSupportedException();
            return serializer.Deserialize(reader);
        }
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            throw new NotImplementedException();
        }
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            if (writer == null) throw new ArgumentNullException("writer");
            if (writer.WriteState != WriteState.Element)
                throw new SerializationException(string.Format("WriteState '{0}' not valid. Caller must write start element before serializing in contentOnly mode.",
                    writer.WriteState));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlDictionaryWriter bufferWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream, Encoding.UTF8))
                {
                    serializer.Serialize(bufferWriter, graph);
                    bufferWriter.Flush();
                    memoryStream.Position = 0;
                    using (XmlReader reader = new XmlTextReader(memoryStream))
                    {
                        reader.MoveToContent();
                        writer.WriteAttributes(reader, false);
                        if (reader.Read()) // move off start node (we want to skip it)
                        {
                            while (reader.NodeType != XmlNodeType.EndElement) // also skip end node.
                                writer.WriteNode(reader, false); // this will take us to the start of the next child node, or the end node.
                            reader.ReadEndElement(); // not necessary, but clean
                        }
                    }
                }
            }
        }
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            throw new NotImplementedException();
        }
        public override void WriteObject(XmlDictionaryWriter writer, object graph)
        {
            Debug.Assert(serializer != null);
            if (writer == null) throw new ArgumentNullException("writer");
            serializer.Serialize(writer, graph);
        }
    }
