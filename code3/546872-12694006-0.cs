    public class StackOverflow_12693581
    {
        [DataContract(Namespace = "", Name = "Test")]
        public class TestData
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
            [DataMember]
            public string MyString { get; set; }
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            void Process(TestData test);
        }
        public class Service : ITest
        {
            public void Process(TestData test)
            {
                Console.WriteLine("MyString: {0}", test.MyString ?? "<<NULL>>");
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            byte[] image = Enumerable.Range(1, 100).Select(i => (byte)i).ToArray();
            WebClient c = new WebClient();
            Console.WriteLine("Order as in the question");
            string data = string.Format("<Test><Id>{0}</Id><Name>{1}</Name><Age>{2}</Age><MyString>{3}</MyString></Test>",
                1, "name", 20, Convert.ToBase64String(image));//image is in bytes 
            c.Headers[HttpRequestHeader.ContentType] = "text/xml";
            c.UploadString(baseAddress + "/Process", data);
            Console.WriteLine();
            c = new WebClient();
            Console.WriteLine("Correct order");
            data = string.Format("<Test><Age>{2}</Age><Id>{0}</Id><MyString>{3}</MyString><Name>{1}</Name></Test>",
                1, "name", 20, Convert.ToBase64String(image));//image is in bytes 
            c.Headers[HttpRequestHeader.ContentType] = "text/xml";
            c.UploadString(baseAddress + "/Process", data);
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
