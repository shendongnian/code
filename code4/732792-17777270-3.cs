    const int columnWidth = 5;
    string cellFormat = "{0, " + columnWidth + "}"; 
    Console.Write("How wide do we want the multiplication table? ");
    int columnsCount = Convert.ToInt32(Console.ReadLine());
    Console.Write("How high do we want the multiplication table? ");
    int rowsCount = Convert.ToInt32(Console.ReadLine());           
    string columnsHeader = String.Format(cellFormat + "|", "x");
    Console.Write(columnsHeader);
    for (int i = 1; i <= columnsCount; i++)
        Console.Write(cellFormat, i);
            
    Console.WriteLine();
    int tableWidth = columnWidth * columnsCount + columnsHeader.Length;
    Console.WriteLine(new String('-', tableWidth));
    for (int row = 1; row <= rowsCount; row++)
    {
        Console.Write(cellFormat + "|", row);
        for (int column = 1; column <= columnsCount; column++)
            Console.Write(cellFormat, row * column);
                
        Console.WriteLine();
    }
