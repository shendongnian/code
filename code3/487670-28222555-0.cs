    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person()
            {
                Name = "Alsafoo",
                Address = new Address()
                {
                    City = "Chicago"
                }
            };
            Person p2 = new Person(p1.Address);
            p2 = p1.GetClone(CloningFlags.Shallow);
            p2.Name = "Ahmed";
            p2.Address = new Address(){City = "Las Vegas"};
            Console.WriteLine("p1 first name: {1} --- p1 city: {2} {0}p2 first name: {3} ---- p2 city: {4}", 
                Environment.NewLine, p1.Name, p1.Address.City, p2.Name, p2.Address.City);
            Console.ReadKey();
        }
    }
    public class Person
    {
        public Person()
        {}
        public Person(Address a)
        {
            Address = a;
        }
        public string Name { get; set; }
        public Address Address { get; set; }        
    }
    public class Address
    {
        public string City { get; set; }
    }
