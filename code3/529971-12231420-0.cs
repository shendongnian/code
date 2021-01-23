    using System.Drawing;
    using System.Drawing.Printing;
    
    public void Print()
    {
      var doc = new PrintDocument();
      doc.PrinterSettings.PrinterName = "\\\\deployment-machine-name\\share-name";
      doc.PrintPage += new PrintPageEventHandler(ProvideContent);
      doc.Print();
    }
    public void ProvideContent(object sender, PrintPageEventArgs e)
    {
      e.Graphics.DrawString(
        "Hello world",
        new Font("Arial", 12),
        Brushes.Black,
        e.MarginBounds.Left,
        e.MarginBounds.Top);
    }
