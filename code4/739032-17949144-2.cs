    namespace ConsoleApplication1
    {
        [XmlRoot(ElementName = "DietPlan")]
        public class TestData
        {
            [XmlAnyElement]
            public List<XmlElement> Fruits { get; set; }
        }
    
        [XmlRoot(ElementName = "DietPlan")]
        public class TestDataForSerialization
        {
            [XmlElement(ElementName = "Fruit")]
            public List<string> Fruits { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                const string XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                        <DietPlan>
                                <Fruit>fig</Fruit>
                                <Fruit>Apple</Fruit>
                                <Fruit>Peach</Fruit>
                        </DietPlan>";
    
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
    
                TestData testdata1 = DeserializeFromStream<TestData>(ms);
                TestDataForSerialization testdata2 = DeserializeFromStream<TestDataForSerialization>(ms);
    
                MemoryStream msserialized1 = SerializeToStream(testdata1);
    
                TestDataForSerialization testdata_toserialize = Convert(testdata1);
                MemoryStream msserialized2 = SerializeToStream(testdata_toserialize);
    
                string xml1 = Encoding.UTF8.GetString(msserialized1.ToArray());
                string xml2 = Encoding.UTF8.GetString(msserialized2.ToArray());
    
                TestData testdata_deserialized1 = DeserializeFromStream<TestData>(msserialized1);
                TestData testdata_deserialized2 = DeserializeFromStream<TestData>(msserialized2);
    
                TestData testdata_deserialized3 = DeserializeFromString<TestData>(xml1);
                TestData testdata_deserialized4 = DeserializeFromString<TestData>(xml2);
            }
    
            public static TestDataForSerialization Convert(TestData testdata)
            {
                TestDataForSerialization testdata_toserialize = new TestDataForSerialization();
                List<string> fruits = new List<string>();
                foreach (XmlElement el in testdata.Fruits)
                {
                    fruits.Add(el.InnerText);
                }
                testdata_toserialize.Fruits = fruits;
    
                return testdata_toserialize;
            }
    
            public static T DeserializeFromStream<T>(MemoryStream ms)
            {
                ms.Seek(0, SeekOrigin.Begin);
    
                var xs = new XmlSerializer(typeof(T));
                var obj = (T)xs.Deserialize(ms);
    
                return obj;
            }
    
            public static T DeserializeFromString<T>(string xml)
            {
                var xs = new XmlSerializer(typeof(TestData));
                var sr = new StringReader(xml);
                var obj = (T)xs.Deserialize(sr);
    
                return obj;
            }
    
            public static MemoryStream SerializeToStream(TestData testdata)
            {
                //How to populate testData with fruitlist ? (Because it is a list of xmlElements!)
    
                var ms = new MemoryStream();
                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    
                XmlAttributes xmlattributes = new XmlAttributes();
    
                XmlElementAttribute attr = new XmlElementAttribute(testdata.Fruits.GetType());
                attr.ElementName = "Fruit";
    
                xmlattributes.XmlElements.Add(attr);
    
                overrides.Add(typeof(List<string>), "Fruits", xmlattributes);
    
                StreamWriter sw = new StreamWriter(ms); // you need to use one of these to get UTF8 output
                var xs = new XmlSerializer(typeof(TestData));
                xs.Serialize(sw, testdata);
    
                return ms;
            }
    
            public static MemoryStream SerializeToStream(TestDataForSerialization testdata)
            {
                //How to populate testData with fruitlist ? (Because it is a list of xmlElements!)
    
                var ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms); // you need to use one of these to get UTF8 output
                var xs = new XmlSerializer(typeof(TestDataForSerialization));
                xs.Serialize(sw, testdata);
    
                return ms;
            }
        }
    }
