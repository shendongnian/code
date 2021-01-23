    private void PrintSomethingNew()
    {
      PrintDialog dialog = new PrintDialog();
      if (dialog.ShowDialog() != true)
      { return; }
    
      StackPanel myPanel = new StackPanel();
      myPanel.Margin = new Thickness(15);
      Image myImage = new Image();
      myImage.Width = 128;
      myImage.Stretch = Stretch.Uniform;
      myImage.Source = new BitmapImage(new Uri("C:\\Tree.jpg", UriKind.Absolute));
      myPanel.Children.Add(myImage);
      TextBlock myBlock = new TextBlock();
      myBlock.Text = "A Great Image.";
      myBlock.TextAlignment = TextAlignment.Center;
      myPanel.Children.Add(myBlock);
    
      myPanel.Measure(new Size(dialog.PrintableAreaWidth,
        dialog.PrintableAreaHeight));
      myPanel.Arrange(new Rect(new Point(0, 0), 
        myPanel.DesiredSize));
  
      dialog.PrintVisual(myPanel, "A Great Image.");
    }
