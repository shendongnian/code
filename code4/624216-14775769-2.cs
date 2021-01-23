        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            string json = "[{\"Age\":28,\"Name\":\"Tom\"},{\"Age\":18,\"Name\":\"Andes\"},{\"Age\":32,\"Name\":\"Lily\"}]";
            List<Person> persons = new List<Person>(JsonHelper.JsonDeserialize<Person[]>(json));
        }
