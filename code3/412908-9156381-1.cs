    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
    
            readPerson(out name, out age);
        }
        static void readPerson(out string name, out int age)
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter age: ");
            age = (int) char.GetNumericValue((char) Console.Read());
            Console.WriteLine("Name: {0}; Age: {1}", name, age.ToString());
        }
    }
