    DataTemplate template = Resources["MyTemplate"] as DataTemplate;
    dynamicDataForm.ContentTemplate = template;
    
    Dispatcher.BeginInvoke(() =>
    {
        ComboBox button = FindVisualChildByName<ComboBox>(this, "MyControl");
        if (button != null)
            button.MouseLeftButtonUp += (s, _) => MessageBox.Show("Click");
    });
