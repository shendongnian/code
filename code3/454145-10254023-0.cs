    public MainWindow()
    {
        InitializeComponent();
        richTextBox.Document = new FlowDocument();
        flowDocumentScrollViewer.Document = new FlowDocument();
    }
    private void CopyDocument(FlowDocument source, FlowDocument target)
    {
        TextRange sourceRange = new TextRange(source.ContentStart, source.ContentEnd);
        MemoryStream stream = new MemoryStream();
        XamlWriter.Save(sourceRange, stream);
        sourceRange.Save(stream, DataFormats.XamlPackage);
        TextRange targetRange = new TextRange(target.ContentStart, target.ContentEnd);
        targetRange.Load(stream, DataFormats.XamlPackage);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        CopyDocument(richTextBox.Document, flowDocumentScrollViewer.Document);
    }
