    Span span = new Span();
    span.Foreground = Brushes.Black;
    span.Inlines.Add(new Run("Text"));
    
    textBlock.Inlines.Add(span);
    
    Label cell = new Label();
    
    cell.MinHeight = cellHeight;
    cell.MaxWidth = cellWidth * 3;
    cell.MinWidth = cellWidth;
    cell.ToolTip = "toolTip";
    cell.BorderThickness = new Thickness(2);
    
    TextBlock cellText = new TextBlock();
    cellText.HorizontalAlignment = HorizontalAlignment.Stretch;
    cellText.TextWrapping = TextWrapping.WrapWithOverflow;
    			
    cell.Content = cellText;
