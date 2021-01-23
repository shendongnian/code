    static void Main(string[] args)
    {
        Console.Write("Your editable text:");
        SendKeys.SendWait("hello"); //hello text will be editable :)
        Console.ReadLine();
    }
