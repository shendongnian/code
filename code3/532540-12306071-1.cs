        public MainWindow()
        {
            InitializeComponent();
            rtb.IsDocumentEnabled = true;
            rtb.Document.Blocks.FirstBlock.Margin = new Thickness(0);
        }
        private void AddHyperlinkText(string linkURL, string linkName, 
                  string TextBeforeLink, string TextAfterLink)
        {
            Paragraph para = new Paragraph();
            para.Margin = new Thickness(0); // remove indent between paragraphs
            Hyperlink link = new Hyperlink();
            link.IsEnabled = true;
            link.Inlines.Add(linkName);
            link.NavigateUri = new Uri(linkURL);
            link.RequestNavigate += (sender, args) => Process.Start(args.Uri.ToString()); 
            para.Inlines.Add(new Run("[" + DateTime.Now.ToLongTimeString() + "]: "));
            para.Inlines.Add(TextBeforeLink);
            para.Inlines.Add(link);
            para.Inlines.Add(new Run(TextAfterLink)); 
            rtb.Document.Blocks.Add(para);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {   
            AddHyperlinkText("http://www.google.com", "http://www.google.com", 
                   "Please visit ", ". Thank you! Some veeeeeeeeeery looooooong text.");
        } 
