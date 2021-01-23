    static void readPerson(out string name, out int age)
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();
        Console.Write("Enter age: ");
        age = 0;
        int tempAge;
        Int32.TryParse(Console.ReadLine(), out tempAge);
        if(tempAge > -1)
        {
            age = tempAge;
        }
        Console.WriteLine("Name: {0}; Age: {1}", name, age);
        Console.ReadLine();
    }
