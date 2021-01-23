    Binding binding = new Binding();
    //binding.Source = typeof(MyStaticClass);
    // System.InvalidOperationException: 'Binding.StaticSource cannot be set while using Binding.Source.'
    binding.Path = new PropertyPath(typeof(MyStaticClass).GetProperty(nameof(MyStaticClass.Left)));
    binding.Mode = BindingMode.TwoWay;
    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    this.SetBinding(Window.LeftProperty, binding);
  
