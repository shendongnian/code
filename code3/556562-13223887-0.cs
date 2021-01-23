    public Control GetControlByDataBinding(string key)
    {
    	foreach (Control control in Controls)
    	{
    		foreach (Binding binding in control.DataBindings)
    		{
    			if (binding.PropertyName == key) return control;
    		}
    	}
    	return null;
    }
