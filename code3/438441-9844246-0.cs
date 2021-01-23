    document.PrintPage += (s, a) =>
    {
        a.Graphics.DrawString("*123456*",
                              BarcodeFont,
                              new SolidBrush(Color.Black),
                              new Point(0, 0));
        a.HasMorePages = false;
    }
