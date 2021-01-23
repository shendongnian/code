    static void Main(string[] args)
    {
        Type type = Type.GetType("System.Int32");
        object obj = Activator.CreateInstance(type);
        int num = (int) obj;
        num = 10;
        Console.WriteLine(num); // prints : 10
    }
