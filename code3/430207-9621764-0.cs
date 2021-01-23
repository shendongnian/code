    int rows = range.Rows.Count;
    int cols = range.Columns.Count;
    for(int r=1; r <= rows; r++)
    {
        for(int c=1; c <= cols; c++)
        {
            Console.Write(range.Cells[r,c].Value2.ToString());
        }
        Console.WriteLine();
    }
