    FrameworkElement fe = control as FrameworkElement;
    foreach(PropertyDescriptor pd in TypeDescriptor.GetProperties(control))
    {
       FieldInfo field = control.GetType().GetField(pd.Name + "Property");
       if(field == null)
           continue;
       DependencyProperty dp = field.GetValue(control) as DependencyProperty;
       if(dp == null)
           continue;
       BindingExpression be = control.GetBindingExpression(dp);
       if(be == null)
           continue;
    
       // do your stuff here
    
    }
