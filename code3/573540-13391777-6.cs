    private void PrintText(string text)
    {
        var printDlg = new PrintDialog();
        var doc = new FlowDocument(new Paragraph(new Run(text)));
        doc.PagePadding = new Thickness(10);
			
        printDlg.PrintDocument((doc as IDocumentPaginatorSource).DocumentPaginator, "Print Caption");
    }
