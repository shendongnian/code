    string oldoutput = "123";
    Console.Write(oldoutput);
    Console.ReadLine();
    string newoutput = "!";
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.Write(newoutput);
    int delta = oldoutput.Length - newoutput.Length;
    if (delta > 0)
    {
        for (int i = 0; i < delta; i++)
            Console.Write(" ");
    }
    Console.ReadLine();
