    var origRow = Console.CursorTop;
    for (int a = 10; a >= 0; a--)
    {
        Console.SetCursorPosition(0, origRow);
        Console.Write("Generating Preview in {0}", a);
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
    }
    Console.SetCursorPosition(0, origRow);
    Console.Write("Generating Preview done.....");
