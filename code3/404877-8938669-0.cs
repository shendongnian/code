    private static void Main()
    {
        Program.Compare1(new Action(Program.Main)).Dump();
        Program.Compare2(new Action(Program.Main)).Dump();
        Console.ReadLine();
    }
    private static bool Compare1(Delegate x)
    {
       return x == new Action(Program.Main);
    }
    private static bool Compare2(Action x)
    {
       return x == new Action(Program.Main);
    }
