    static bool TryDeserialize<T>(string xmlStr, out T obj) {
        var ser = new XmlSerializer(typeof(T));
        using(var stringReader = new StringReader(xmlStr)) {
            using (var xmlReader = new XmlTextReader(stringReader)) {
                try {
                    obj = ser.Deserialize(xmlReader);
                } catch {
                    obj = default(T);
                    return false;
                }
            }
        }
        return true;
    }
