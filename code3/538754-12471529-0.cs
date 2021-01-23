    for (int page = 2; page <= reader.NumberOfPages; page++)
    {
        var strategy = new SimpleTextExtractionStrategy();
        string text = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
        iResult.Text = text;
    }
