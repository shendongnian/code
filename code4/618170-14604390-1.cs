    interface IPerson
    {
        string MobileNo { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
    }
    class Person : IPerson
    {
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    class execute
    {
        private Dictionary<string, object[]> dictionary = new Dictionary<string,object[]>();
        public void run()
        {
            List<IPerson> persons = new List<IPerson>();
            persons.Add(new Person()
            {
                LastName = "asdf",
                Name = "asdf",
                MobileNo = "123123"
            });
            persons.Add(new Person()
            {
                LastName = "aaaa",
                Name = "dddd",
                MobileNo = "1231232"
            });
            string x = PersonList("somelistname", persons);
        }
        public string PersonList(string listName, IEnumerable<IPerson> persons)
        {
            //dictionary.Add("name", new String[1] { listName });
            dictionary.Add("list", persons.ToArray());
            return PrivateMethod("personList", dictionary);
        }
        private string PrivateMethod(string value, Dictionary<string, object[]> parameters)
        {
            foreach (KeyValuePair<string, object[]> kvp in parameters)
            {
                IPerson[] persons = kvp.Value.Cast<IPerson>().ToArray();
            }
            return "somestring";
        }
