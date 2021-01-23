    public class StackOverflow_14945653
    {
        [DataContract]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
            [DataMember]
            public Address Address { get; set; }
        }
        [DataContract]
        public class Address
        {
            [DataMember]
            public string Street;
            [DataMember]
            public string City;
            [DataMember]
            public string Zip;
        }
        [ServiceContract]
        public interface ITest
        {
            [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            void RegisterPerson(Person p);
            [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            Person FindPerson(string name);
        }
        public class Service : ITest
        {
            private static List<Person> AllPeople = new List<Person>();
            public void RegisterPerson(Person p)
            {
                AllPeople.Add(p);
            }
            public Person FindPerson(string name)
            {
                return AllPeople.Where(p => p.Name == name).FirstOrDefault();
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            Console.WriteLine("Accessing via WebChannelFactory<T>");
            WebChannelFactory<ITest> factory = new WebChannelFactory<ITest>(new Uri(baseAddress));
            ITest proxy = factory.CreateChannel();
            proxy.RegisterPerson(new Person
            {
                Name = "John Doe",
                Age = 32,
                Address = new Address
                {
                    City = "Springfield",
                    Street = "123 Main St",
                    Zip = "12345"
                }
            });
            Console.WriteLine(proxy.FindPerson("John Doe").Age);
            Console.WriteLine();
            Console.WriteLine("Accessing via \"normal\" HTTP client");
            string jsonInput = "{'Name':'Jane Roe','Age':30,'Address':{'Street':'1 Wall St','City':'Springfield','Zip':'12346'}}".Replace('\'', '\"');
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            c.UploadString(baseAddress + "/RegisterPerson", jsonInput);
            c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/FindPerson?name=Jane Roe"));
            Console.WriteLine();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
