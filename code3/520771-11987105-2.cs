    FooViewModel model = new FooViewModel();
    
    FooView view = new FooView(model);
    view.DataContext = model;
    view.Show();
    model.Value = "ABC";
    
    
    public FooView(FooViewModel model)
    {
        Binding myBinding = new Binding("Value");
        myBinding.Source = model;
        myBinding.Mode = BindingMode.TwoWay;
        myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    
        BindingOperations.SetBinding(this, this.Value, myBinding);
    }
