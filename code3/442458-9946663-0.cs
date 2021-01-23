    PrintDocument pd = new PrintDocument();
    pd.PrintPage += (sender, args) => DrawImage(filePath, args.Graphics);
    pd.Print();
    ...
    private static void DrawImage(string filePath, Graphics graphics)
    {
        ...
    }
