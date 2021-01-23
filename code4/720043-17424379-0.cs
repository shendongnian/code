    static void Main(string[] args)
    {
        bool valueA = true;
        bool valueB = valueA;
        // Both will print TRUE
        Console.WriteLine("ValueA is: " + valueA.ToString());
        Console.WriteLine("ValueB is: " + valueB.ToString());
	
        // Change valueA but leave valueB unchanged
        valueA = false;
        // valueA now FALSE while valueB is still TRUE
        Console.WriteLine("ValueA is: " + valueA.ToString());
        Console.WriteLine("ValueB is: " + valueB.ToString());
        Console.ReadKey();
    }
