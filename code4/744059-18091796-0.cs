    public class StackOverflow_18081074
    {
        [DataContract]
        public class Person
        {
            [DataMember(Name = "0")]
            public string Foo1 { get; set; }
            [DataMember(Name = "1")]
            public string Foo2 { get; set; }
            [DataMember(Name = "2")]
            public string Foo3 { get; set; }
        }
        [ServiceContract]
        public class Service
        {
            [WebGet]
            public Person Get()
            {
                return new Person
                {
                    Foo1 = "bar1",
                    Foo2 = "bar2",
                    Foo3 = "bar3"
                };
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/Get"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
