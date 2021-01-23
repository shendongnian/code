    public class KeyValue
    {
        public string Key;
        public string Value;
    }
    
    static void Save()
    {
        // some test data
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("key1", "value1");
        dict.Add("key2", "value2");
        dict.Add("key3", "value3");
        dict.Add("key4", "value4");
        // convert to List
        List<KeyValue> list1 = (from itm in dict
                                select new KeyValue
                                           {
                                               Key = itm.Key, Value = itm.Value
                                           }).ToList();
        // serialize
        using (StreamWriter sw = new StreamWriter("C:\\temp\\config.xml"))
        {
            XmlSerializer xs = new XmlSerializer(typeof (List<KeyValue>));
            xs.Serialize(sw, list1);
            sw.Close();
        }
    }
    static void Load()
    {
        // deserialize
        using (StreamReader sr = new StreamReader("c:\\temp\\config.xml"))
        {
            XmlSerializer xs = new XmlSerializer(typeof (List<KeyValue>));
            List<KeyValue> list2 = (List<KeyValue>) xs.Deserialize(sr);
            sr.Close();
        }
        
        // convert to Dictionary
        Dictionary<string, string> dict2 = list2.ToDictionary(x => x.Key, x => x.Value);
    }
