    Binding frameBinding = new Binding();
    frameBinding.Path = new PropertyPath("PageName"); // here
    frameBinding.Source = mainWindowViewModel; // and here
    frameBinding.Converter = this;
    frameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    frameBinding.IsAsync = true;
    frame.SetBinding(Frame.ContentProperty, frameBinding);
