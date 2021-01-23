    public class StackOverflow_15907357
    {
        const string XML = @"<?xml version=""1.0""?>
                            <DietPlan>
                                <Health>
                                    <Fruit>Test</Fruit>
                                    <Fruit>Test</Fruit>
                                    <Veggie>Test</Veggie>
                                    <Veggie>Test</Veggie>
                                </Health>
                            </DietPlan>";
        [XmlRoot(ElementName = "DietPlan")]
        public class TestSerialization
        {
            [XmlArray("Health")]
            [XmlArrayItem("Fruit", Type = typeof(Fruit))]
            [XmlArrayItem("Veggie", Type = typeof(Veggie))]
            public Food[] Foods { get; set; }
        }
        [XmlInclude(typeof(Fruit))]
        [XmlInclude(typeof(Veggie))]
        public class Food
        {
            [XmlText]
            public string Text { get; set; }
        }
        public class Fruit : Food { }
        public class Veggie : Food { }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
            XmlSerializer xs = new XmlSerializer(typeof(TestSerialization));
            TestSerialization obj = (TestSerialization)xs.Deserialize(ms);
            foreach (var food in obj.Foods)
            {
                Console.WriteLine("{0}: {1}", food.GetType().Name, food.Text);
            }
        }
    }
