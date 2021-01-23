    class Program
    {
        static void Main(string[] args)
        {
            string name;
            char age;
    
            readPerson(out name, out age);
        }
        static void readPerson(out string name, out char age)
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter age: ");
            age = (char) Console.Read();
            Console.WriteLine("Name: {0}; Age: {1}", name, age.ToString());
        }
    }
