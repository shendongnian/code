    FlowDocument flowDoc = new FlowDocument();
    Paragraph header = new Paragraph();
    Grid imageGrid = new Grid();
    imageGrid.ColumnDefinitions.Add(new ColumnDefinition());
    ColumnDefinition colDef = new ColumnDefinition();
    colDef.Width = new GridLength(4, GridUnitType.Star);
    imageGrid.ColumnDefinitions.Add(colDef);
    imageGrid.ColumnDefinitions.Add(new ColumnDefinition());
    BitmapImage bitImage = new BitmapImage(new Uri("{...}", UriKind.RelativeOrAbsolute));
    Image image = new Image();
    image.Source = bitImage;
    image.Margin = new Thickness(10.0d);
    Grid.SetColumn(image, 1);
    imageGrid.Children.Add(image);
    header.Inlines.Add(imageGrid);
    header.Inlines.Add(new LineBreak());
    
    header.Inlines.Add("Some text here");
    header.Inlines.Add(new LineBreak());
    flowDoc.Blocks.Add(header);
        
