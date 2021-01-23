    public TestWindow()
    {
    InitializeComponent();
    this.paragraph = new Paragraph();
    rich1.Document = new FlowDocument(paragraph);
    var from = "user1";
    var text = "chat message goes here";
    paragraph.Inlines.Add(new Bold(new Run(from + ": "))
    {
        Foreground = Brushes.Red
    });
    paragraph.Inlines.Add(text);
    paragraph.Inlines.Add(new LineBreak());
    this.DataContext = this;
    }
    private Paragraph paragraph;
