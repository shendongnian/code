    Console.Write("How wide do we want the multiplication table? ");
    int columnsCount = Convert.ToInt32(Console.ReadLine());
    Console.Write("How high do we want the multiplication table? ");
    int rowsCount = Convert.ToInt32(Console.ReadLine());
    MultiplicationTable table = new MultiplicationTable(columnsCount, rowsCount);
    table.Draw();
