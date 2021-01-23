    public Control GetControlByDataBinding(string key)
    {
    	return 
    		Controls
    		.Cast<Control>()
    		.FirstOrDefault(control => 
    			control.DataBindings
    			.Cast<Binding>()
    			.Any(binding => binding.PropertyName == key));
    }
