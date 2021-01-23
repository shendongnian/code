    class Program
    {
        static void Main(string[] args)
        {
            Person alan = new Person();
            alan.PersonName = "Alan";
            Console.WriteLine("Hi " + alan.PersonName);
            Console.ReadLine();
        }
    }
    class Person
    {
        public string PersonName { get; set; }
    }
