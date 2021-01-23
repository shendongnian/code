    var binding = new Binding
    {
        Path = new PropertyPath(typeof(Test).GetProperty("Prop")),
        Mode = BindingMode.OneWayToSource,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    };
    BindingOperations.SetBinding(textBox1, TextBox.TextProperty, binding);
