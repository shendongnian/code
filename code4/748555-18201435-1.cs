    private void ChangeStyle_Click(object sender, RoutedEventArgs e)
    {
        Style style = new Style 
        { 
            TargetType = typeof(Label) 
        };
        style.Setters.Add(new Setter(Label.BackgroundProperty, Brushes.Aquamarine));
        Application.Current.Resources["MyStyle"] = style;
    }	
