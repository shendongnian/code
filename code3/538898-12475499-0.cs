    static void Main(string[] args)
    {
        string User;            
        if (args.Length  != 0) // Change from args[0] to args
        {
             User = args[0];
        }
        else
        {
        Console.Write("Please Enter the Username");
        User = Console.ReadLine();
        }
    }
