    class Deserialised<T>
        where T : IResult
    {
        private T result;
        private Type resultType;
        public Deserialised(T _result)
        {
            result = _result;
        }
        public T getObject(XmlDocument xml)
        {
            var mySerializer = new XmlSerializer(typeof(T));
            var myStream = new MemoryStream();
            xml.Save(myStream);
            myStream.Position = 0;
            var r = (T)mySerializer.Deserialize(myStream);
            return r;
        }
    }
