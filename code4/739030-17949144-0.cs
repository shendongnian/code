    namespace ConsoleApplication1
    {
        [XmlRoot(ElementName = "DietPlan")]
        public class TestData
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
    
                TestData td = Deserialize(ms);
    
                var testData = new TestData()
                {
                    Fruits = new List<string> { "fig", "Apple", "Peach" }
                };
    
                var ms2 = Serialize(testData);
    
                ms2.Seek(0, SeekOrigin.Begin);
    
                TestData td2 = Deserialize(ms2);
            }
    
            public static TestData Deserialize(MemoryStream ms)
            {
                var xs = new XmlSerializer(typeof(TestData));
                var obj = (TestData)xs.Deserialize(ms);
    
                return obj;
            }
    
            public static MemoryStream Serialize(TestData testdata)
            {
                //How to populate testData with fruitlist ? (Because it is a list of xmlElements!)
    
                var ms = new MemoryStream();
                var xs = new XmlSerializer(typeof(TestData));
                xs.Serialize(ms, testdata);
    
                return ms;
            }
        }
    }
