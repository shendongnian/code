    static void readPerson(out string name, out int age)
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();
        Console.Write("Enter age: ");
        // in this case, we could simply use tempAge (defaults to 0)
        // but it's just practice to check TryParse's success flag
        int tempAge;
        var success = Int32.TryParse(Console.ReadLine(), out tempAge);
        age = success ? tempAge : 0;
        Console.WriteLine("Name: {0}; Age: {1}", name, age);
        Console.ReadLine();
    }
