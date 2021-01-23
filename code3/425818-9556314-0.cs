    ...
    MyRTB.SelectionChanged += OnSelectionChanged;
    ...
    
    
    void OnSelectionChanged()
    {
     var fontSize = MyRTB.Selection.GetPropertyValue(TextElement.FontSizeProperty);
     if (fontSize == DependencyProperty.UnsetValue)
     {
      // Selection has text with different font sizes.
     }
     else {
      // (double)fontSize is the current font size. Update Cmb_Font.. 
     }
    }
