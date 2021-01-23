    public static  Binding GetValueBinding(MyControl control)
    {
       Binding valueBinding = new Binding();
       valueBinding.Mode = BindingMode.TwoWay;
       valueBinding.Path = new PropertyPath("MyControls["+control.Id+"].Value");
       return valueBinding;
    }
