    const string title = "    x|";
    const int columnWidth = 5;
    Console.Write("How wide do we want the multiplication table? ");
    int columnsCount = Convert.ToInt32(Console.ReadLine());
    Console.Write("How high do we want the multiplication table? ");
    int height = Convert.ToInt32(Console.ReadLine());           
    Console.Write(title);            
    for (int i = 1; i <= columnsCount; i++)
        Console.Write("{0, " + columnWidth + "}", i);
            
    Console.WriteLine();
    Console.WriteLine(new String('-', columnWidth * columnsCount + title.Length));
