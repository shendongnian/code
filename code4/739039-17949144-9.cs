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
                TestData testdata3 = new TestData()
                {
                    Fruits = new List<XmlElement>
                    {
                        GetFruitElement("fig"),
                        GetFruitElement("Apple"),
                        GetFruitElement("Peach")
                    }
                };
                TestDataForSerialization testdata4 = new TestDataForSerialization()
                {
                    Fruits = new List<string> { "fig", "Apple", "Peach" }
                };
                TestDataForSerialization testdata5 = Convert(testdata1);
    
                MemoryStream msserialized1 = SerializeToStream<TestData>(testdata1);
                MemoryStream msserialized2 = SerializeToStream<TestDataForSerialization>(testdata2);
                MemoryStream msserialized3 = SerializeToStream<TestData>(testdata3);
                MemoryStream msserialized4 = SerializeToStream<TestDataForSerialization>(testdata4);
                MemoryStream msserialized5 = SerializeToStream(testdata5);
    
                string xml1 = Encoding.UTF8.GetString(msserialized1.ToArray());
                string xml2 = Encoding.UTF8.GetString(msserialized2.ToArray());
                string xml3 = Encoding.UTF8.GetString(msserialized3.ToArray());
                string xml4 = Encoding.UTF8.GetString(msserialized4.ToArray());
                string xml5 = Encoding.UTF8.GetString(msserialized5.ToArray());
    
                TestData testdata_deserialized1 = DeserializeFromStream<TestData>(msserialized1);
                TestData testdata_deserialized2 = DeserializeFromStream<TestData>(msserialized2);
                TestData testdata_deserialized3 = DeserializeFromStream<TestData>(msserialized3);
                TestData testdata_deserialized4 = DeserializeFromStream<TestData>(msserialized4);
                TestData testdata_deserialized5 = DeserializeFromStream<TestData>(msserialized5);
    
                TestData testdata_deserialized6 = DeserializeFromString<TestData>(xml1);
                TestData testdata_deserialized7 = DeserializeFromString<TestData>(xml2);
                TestData testdata_deserialized8 = DeserializeFromString<TestData>(xml3);
                TestData testdata_deserialized9 = DeserializeFromString<TestData>(xml4);
                TestData testdata_deserialized10 = DeserializeFromString<TestData>(xml5);
            }
    
            public static XmlElement GetFruitElement(string fruit)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Fruit>" + fruit + "</Fruit>");
                return doc.DocumentElement;
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
    
            public static MemoryStream SerializeToStream<T>(T testdata)
            {
                var ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms); // you need to use one of these to get UTF8 output
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, testdata);
    
                return ms;
            }
        }
    }
