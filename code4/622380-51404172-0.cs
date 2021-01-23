    static void Main()
    {
        using (var s = Console.OpenStandardInput())
        using (var sr = new StreamReader(s))
        {
            Task readLineTask = sr.ReadLineAsync();
            Debug.WriteLine("hi");
            Console.WriteLine("hello");
            readLineTask.Wait();// When not in Main method, you can use await. 
                                // Waiting must happen in the curly brackets of the using directive.
        }
        Console.WriteLine("Bye Bye");
    }
