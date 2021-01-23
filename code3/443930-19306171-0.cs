    PrintDocument pd = new PrintDocument();
    pd.DefaultPageSettings.PrinterSettings.PrinterName = "Printer Name";
    pd.DefaultPageSettings.Landscape = true; //or false!
    pd.PrintPage += (sender, args) =>
    {
        Image i = Image.FromFile(@"C:\...\...\image.jpg");
        Rectangle m = args.MarginBounds;
        if (i.Width / i.Height > m.Width / m.Height) // image is wider
        {
             m.Height = (i.Width / i.Height * m.Width);
        }
        else
        {
             m.Width = (i.Width / i.Height * m.Height);
        }
        args.Graphics.DrawImage(i, m);
    };
    pd.Print();
