    static void Main(string[] args)
    {
        Run().Wait();
        //Problem or Maybe Not? Needs this 
        //So that my application won't close immediately
        //Console.ReadLine();
    }
    // note the return type is Task
    private async static Task Run()
    {
    ...
    }
