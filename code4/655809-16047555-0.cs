    public class OuterItem
    {
        [XmlArrayItem(ElementName="ItemValue", Type=typeof(string))]
        [XmlArray]
        public string[] InnerItem
        {
            get; set;
        }
    }
    public class Test
    {
        static void Main()
        {
            var item = new OuterItem { InnerItem = new[]{"AAA"} };
            XmlSerializer ser = new XmlSerializer(typeof(OuterItem));
            ser.Serialize(Console.Out,item);
        }
    }
