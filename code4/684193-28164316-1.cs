        public static void Main(string[] args)
        {
            C2 c2 = new C2();
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer ser = GetXmlSerializerWithXmlIgnoreFields(typeof(C2));
                ser.Serialize(ms, c2);
                string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine(result);
            }
        }
