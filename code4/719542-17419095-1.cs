    public void Print()
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog().Value)
        {
            var printCapabilities = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);
            var printSize = new Size(printCapabilities.PageImageableArea.ExtentWidth, printCapabilities.PageImageableArea.ExtentHeight);
            var printPage = new Page();
            printPage.Content = this.FindResource("PrintTestResource");
            printPage.Measure(printSize);
            printPage.Arrange(new Rect(new Point(printCapabilities.PageImageableArea.OriginWidth, printCapabilities.PageImageableArea.OriginHeight), printSize));
            printDialog.PrintVisual(printPage, String.Empty);
        }
    }
