    void PrintNewTreeView()
    {
        var pd = new PrintDocument();
        pd.PrintPage += OnPrintPage;
        pd.Print(); 
    }
    
    void OnPrintPage(object sender, PrintPageEventArgs e)
    {
        var bitmap = new Bitmap(newTreeView.Bounds.Size);
        newTreeView.DrawToBitmap(bitmap, bitmap.Size);
        var pt = Point.Empty; // drawing origin
        e.Graphics.DrawImage(bitmap, pt);
    }
