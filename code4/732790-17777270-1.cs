    const string title = "    x|";
    const int columnWidth = 5;
    Console.Write("How wide do we want the multiplication table? ");
    int columnsCount = Convert.ToInt32(Console.ReadLine());
    Console.Write("How high do we want the multiplication table? ");
    int height = Convert.ToInt32(Console.ReadLine());           
    Console.Write(title);
    string cellFormat = "{0, " + columnWidth + "}";          
    for (int i = 1; i <= columnsCount; i++)
        Console.Write(cellFormat, i);
            
    Console.WriteLine();
    int tableWidth = columnWidth * columnsCount + title.Length;
    Console.WriteLine(new String('-', tableWidth));
    for (int row = 1; row <= rowsCount; row++)
    {
        Console.Write("{0,5}|", row);
        for (int column = 1; column <= columnsCount; column++)
            Console.Write(cellFormat, row * column);
                
        Console.WriteLine();
    }
