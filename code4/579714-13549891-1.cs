    Binding binding = new Binding();
    binding.Source = typeof(Country);
    binding.Path = new PropertyPath(typeof(Country).GetProperty("Name"));
    binding.Mode = BindingMode.TwoWay;
    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    this.tbCountry.SetBinding(TextBox.TextProperty, binding);
