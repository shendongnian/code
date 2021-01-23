    using System.IO;
    using System.Xml.Serialization;
    namespace Plugin
    {
        public class state
        {
            public int a;
            public int b;
        }
        public class xyz
        {
            public static void Main()
            {
                state s = new state();
                s.a = 3;
                s.b = 5;
                XmlSerializer x = new XmlSerializer(s.GetType());
                using (StreamWriter sw = new StreamWriter(@"E:\state\state.xml"))
                {
                    x.Serialize(sw, s);
                }
            }
        }
    }
