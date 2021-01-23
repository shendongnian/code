    Binding frameBinding = new Binding
    {
        Path = new PropertyPath("PageName"),
        Source = mainWindowViewModel,
        Converter = this,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        IsAsync = true
    };
    frame.SetBinding(Frame.ContentProperty, frameBinding);
