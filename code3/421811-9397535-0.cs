    static void Main(string[] args)
    {
        List<string> sampleList = new List<string>(new string[]
        {
            "Some String", "Some Other String", "Hello World", "123456789", "987654123"
        });
        Console.WriteLine("Items:");
        foreach (string item in sampleList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nRemoving items containing \"123\"...");
        int itemsRemoved = sampleList.RemoveAll(str => str.Contains("123"));
        Console.WriteLine("Removed {0} items.", itemsRemoved);
        Console.WriteLine("\nItems:");
        foreach (string item in sampleList)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }
