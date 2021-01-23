    PrintDocument pd = new PrintDocument();
    pd.PrintPage += (sender, args) => 
    {
        Image i = Image.FromFile(filePath);
        Point p = new Point(100, 100);
        args.Graphics.DrawImage(i, p);
    };
    pd.Print();
