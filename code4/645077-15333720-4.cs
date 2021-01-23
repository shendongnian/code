    static void Main(string[] args)
    {
        string path = "YOU_CLIENT_PROJECT_NAME.exe";
        for (int i = 0; i < 150; i++ )
        {
            Console.WriteLine(i);
            Process.Start(path);
            Thread.Sleep(50);
        }
        Console.WriteLine("Done");
        Console.ReadLine();
    }
