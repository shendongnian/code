    private void DisplayCountDown()
    {
        for (int i = 20; i >= 0; --i)
        {
            int l = Console.CursorLeft;
            int t = Console.CursorTop;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.Write("Time: {0}    ", i);
            Console.CursorLeft = l;
            Console.CursorTop = t;
            Thread.Sleep(1000);
        }
    }
