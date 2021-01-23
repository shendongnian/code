    public class Person
    {
        public string Name { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    public class PersonCollection : List<Person>
    {
        public object[] GetValues(string propertyName)
        {
            var result = new List<object>();
            foreach (Person item in this)
            {
                result.Add(item.GetType().GetProperty(propertyName).GetValue(item));
            }
            return result.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new PersonCollection();
            collection.Add(new Person(){Name = "George", Property1 = "aaa", Property2 = "bbbb"});
            collection.Add(new Person(){Name = "Peter", Property1 = "ccc", Property2 = "dddd"});
            var objects = collection.GetValues("Property1");
            foreach (object item in objects)
            {
                Console.WriteLine(item.ToString());
            }
            Console.Read();
        }
    }
