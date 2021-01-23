    ...
    public static readonly DependencyProperty DefaultProperty =
        DependencyProperty.RegisterAttached(
            "Default",
            typeof(string),
            typeof(MyOptions),
            //Listen for changes in "Default":
            new PropertyMetadata(null, OnMyDefaultChanged));
    private static void OnMyDefaultChanged(DependencyObject sender, 
                                           DependencyPropertyChangedEventArgs e)
    {
        var text = (TextBox)sender;
        var myDefault = e.NewValue;
        var defaultLabel = new Label();
        defaultLabel.Foreground = Brushes.LightGray;
        //Explicitly bind the needed value from the TextBox:
        defaultLabel.SetBinding(Label.ContentProperty,
                                new Binding()
                                {
                                    Source = text,
                                    Path = new PropertyPath(MyOptions.DefaultProperty)
                                });
        text.Background = new VisualBrush()
        {
            Visual = defaultLabel,
            AlignmentX = AlignmentX.Left,
            AlignmentY = AlignmentY.Center,
            Stretch = Stretch.None
        };
        text.TextChanged += new TextChangedEventHandler(OnTextWithDefaultChanged);
    }
    private static void OnTextWithDefaultChanged(object sender, 
                                                 TextChangedEventArgs e)
    {
        var text = (TextBox)sender;
        var defaultLabel = (text.Background as VisualBrush).Visual as Label;
        defaultLabel.Visibility = string.IsNullOrEmpty(text.Text) ? 
                                                    Visibility.Visible : 
                                                    Visibility.Collapsed;
    }
