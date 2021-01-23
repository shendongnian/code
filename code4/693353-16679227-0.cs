    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Select(c => c.FirstName).DoSomething();
        }
    }
    public static class StringListExtension
    {
        public static int DoSomething(this IEnumerable<string> strList)
        {
            return strList.Count();
        }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
