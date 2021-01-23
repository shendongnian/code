    internal override void Print(string printerName, string baseFilePath, string baseFileName)
    {
        using (var printQueue = GetPrintQueue(printerName))
        {
            XpsDocumentWriter xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
            IEnumerable<string> filesToPrint = GetFilesToPrint(baseFilePath, baseFileName);
            PrintUsingCollator(xpsDocumentWriter, filesToPrint);
        }
    }
    private static void PrintUsingCollator(XpsDocumentWriter xpsDocumentWriter,
                                           IEnumerable<string> filesToPrint)
    {
        SerializerWriterCollator collator = xpsDocumentWriter.CreateVisualsCollator();
        collator.BeginBatchWrite();
        foreach (var fileName in filesToPrint)
        {
            Image image = CreateImage(fileName);
            ArrangeElement(image);
            collator.Write(image);
        }
        collator.EndBatchWrite();
    }
    /// <remarks>
    /// This method needs to be called in order for the element to print the right size.
    /// </remarks>
    private static void ArrangeElement(UIElement element)
    {
        var box = new Viewbox {Child = element};
        box.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        box.Arrange(new Rect(box.DesiredSize));
    }
