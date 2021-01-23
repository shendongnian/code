    public Control.ControlCollection RealControls
    {
    	get
    	{
    		return base.Controls;
    	}
    }
    public new CustomControlCollection Controls { get; private set; }
    
    public ContainerControl ControlContainer { get; set; }
