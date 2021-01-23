    var hyperlink    = new HyperLink(new Run("Click Here"));
    hyperlink.Click += new RoutedEventHandler(tbGoToNextTab_Click);
    
    var span = new Span();
    span.Inlines.Add(new Run("Please "));
    span.Inlines.Add(hyperlink);
    span.Inlines.Add(new Run(" to go to next Page"));
    
    var tbGoToNextTab = new TextBlock
    {
      Content = span,
      Foreground = new SolidColorBrush(Colors.Black)
    };
