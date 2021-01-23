    class MySerializer
    {
        private System.IO.Stream myStream = null;
    
        public MySerializer(system.IO.Stream stream)
        {
            this.myStream = stream;
        }
    
        public void Serialize(object data)
        {
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.SerializationXmlSerializer(data.GetType());
    
    	System.XML.XmlWriter writer = System.XML XmlWriter.Create(this.MyStream);
    
    	serializer.Serialize(writer, data);
        }
    }
