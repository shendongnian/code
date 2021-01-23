    public static object DeserializeFromXML<T>(string _input)
        {
            object _temp = Activator.CreateInstance<T>();
            Type expected_type = _temp.GetType();
            _temp = null;
            XmlSerializer serializer = new XmlSerializer(expected_type);
            StringReader stringWriter = new StringReader(_input);
            object _copy = serializer.Deserialize(stringWriter);
            return _copy;
        }
