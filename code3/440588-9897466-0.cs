    public ControlBind(Control control, System.Windows.DependencyProperty controlPropertyToBind)
    {
       Binding b = new Binding("Value")
       {
         Source = this,
         Converter = new MyCurrencyConverter() //Converter
       };
    
       b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
       control.SetBinding(controlPropertyToBind, b);
    }
