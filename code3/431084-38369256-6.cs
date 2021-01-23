    public class SerializableEntity<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static XmlSerializer _typeSpecificSerializer;
    
        private static XmlSerializer TypeSpecificSerializer
        {
            get
            {
                // Only create an instance the first time. In practice, 
                // that will mean once for each variation of T that is used,
                // as each will cause a new class to be created.
                if ((_typeSpecificSerializer == null))
                {
                    _typeSpecificSerializer = 
                        new XmlSerializerFactory().CreateSerializer(typeof(T));
                }
                return _typeSpecificSerializer;
            }
        }
        public virtual string Serialize()
        {
            // .... prepare for serializing...
            // Access _typeSpecificSerializer via the property, 
            // and call the Serialize method, which depends on 
            // the specific type T of "this":
            TypeSpecificSerializer.Serialize(xmlWriter, this);
         }
    }
