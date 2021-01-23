    public MyControl : SomeControl
    {
    
        protected override void CreateChildControls() {
    
    	base.CreateChildControls();
    
    
    	ChildControlsCreated = true;
        } 
    
    }
