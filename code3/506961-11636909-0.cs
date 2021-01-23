      EnvironmentalVariables.ToolTipVisibility = System.Windows.Visibility.Collapsed;
    
      var b = new Button () { Content = "test" };
      var x = new ToolTip();
      x.Content = "This is text.";
      var binding = new Binding {
        Source = EnvironmentalVariables.ToolTipVisibility,
      };
      x.SetBinding(VisibilityProperty, binding);
      b.ToolTip = x;
