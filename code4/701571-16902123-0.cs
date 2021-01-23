        public class Request
        {
            [XmlArray(ElementName = "MyEnums")]
            [XmlArrayItem(ElementName = "ModifiedElementName")]
            public List<MyEnum> MyEnums { get; set; }
        }
        public enum MyEnum
        {
            One,
            Two,
            Three
        }
        public static void Test()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Request));
            MemoryStream ms = new MemoryStream();
            Request req = new Request
            { 
                MyEnums = new List<MyEnum>
                {
                    MyEnum.One,
                    MyEnum.Two,
                    MyEnum.Three
                }
            };
            xs.Serialize(ms, req);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
