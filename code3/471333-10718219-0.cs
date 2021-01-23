    public Intro()
    {
        InitializeComponent();
        richTextBox1.IsEnabled = false;
        Task.Factory.StartNew( () =>
        {
           WebClient wc = new WebClient();
           string source = wc.DownloadString("http://example.com");
           HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
           doc.LoadHtml(source);
           var nodes = doc.DocumentNode.SelectNodes("//a[starts-with(@class, 'url')]");
           return nodes;
        }).ContinueWith( result =>
        {
          richTextBox1.IsEnabled = true;
          if (result.Exception != null) throw result.Exception;
          foreach (var node in result.Result)
          {
               HtmlAttribute att = node.Attributes["href"];
               richTextBox1.Text = richTextBox1.Text + att.Value + "\n";
          }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
