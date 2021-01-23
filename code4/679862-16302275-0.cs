    private void button3_Click_1(object sender, EventArgs e)
    {
        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(Print_Page);
        PrintPreviewDialog dlg = new PrintPreviewDialog();
        dlg.Document = pd;
        dlg.ShowDialog();
        pd.Print();
    }       
    
    private void Print_Page(object o, PrintPageEventArgs e)
    {
        nPaginasImpressas++;
        System.Drawing.Image i = System.Drawing.Image.FromFile("C:\\" + nPaginasImpressas + ".bmp");
        Point p = new Point(0, 0);
        e.Graphics.DrawImage(i, p);
        e.HasMorePages = File.Exists("C:\\" + (nPaginasImpressas + 1) + ".bmp");
    }
