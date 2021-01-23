    private static void PrintControl(Control control)
    {
        var bitmap = new Bitmap(control.Width, control.Height);
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
        var pd = new PrintDocument();
        pd.PrintPage += (s, e) => e.Graphics.DrawImage(bitmap, 100, 100);
        pd.Print();
    }
