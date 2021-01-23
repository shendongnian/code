    AdViewModel vm = new AdViewModel;      
    Binding binding = new Binding
    {
        Path = new PropertyPath("Width"),
        Source = vm.Image
    };
    nameOfGridInXaml.SetBinding(Image.WidthProperty, binding);
