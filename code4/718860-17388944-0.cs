            viewmodel Vm = (e.Error.BindingInError as BindingExpression).DataItem as viewmodel ;// Take viem model from data item. (I think that data item is the binding of the window - not sure)
   
            string propName= (e.Error.BindingInError as BindingExpression).ParentBinding.Path.Path;// The path is the prop name
            System.Reflection.PropertyInfo prop = Vm.GetType().GetProperty(propName);// Here the prop
            var valProp = prop.GetValue(Vm, null);//Here the value
