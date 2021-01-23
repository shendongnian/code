    Console.WriteLine("Hello!");
    Console.WriteLine("This is my command shell.");
    string text = "";
    string toWrite = "Please write something: ";
    while (text != "quit")
    {
        Console.Write(toWrite);
        text = Console.ReadLine();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine(text.PadRight(text.Length + toWrite.Length));
    }
