    internal class Program
        {
            private static void Main(string[] args)
            {
                var list = new MyObject();
                list.Titles.Add("title1");
                list.Titles.Add("title2");
                list.Titles.Add("title3");
    
                string serialized = list.XmlSerialize();
    
                //obviously here you would save to disk or whatever
                Console.WriteLine(serialized);
                Console.ReadLine();
            }
        }
    
        [XmlRoot("Titles")]
        public class MyObject
        {
            [XmlElement("title")]
            public List<string> Titles { get; set; }
    
            public MyObject()
            {
                Titles = new List<string>();
            }
        }
