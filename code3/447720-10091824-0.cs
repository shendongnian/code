    public class StackOverflow_10089682
    {
        [DataContract(Name = "Person", Namespace = "http://my.namespace")]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(ms, Encoding.Unicode);
            DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
            Person instance = new Person { Name = "John Doe", Age = 33 };
            dcs.WriteObject(writer, instance);
            writer.Flush(); // Don't forget to Flush the writer here
            Console.WriteLine("Decoding using UTF-16: {0}", Encoding.Unicode.GetString(ms.ToArray()));
        }
    }
