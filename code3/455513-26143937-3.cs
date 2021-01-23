    ExampleDropDownControlCollectionUIEditor : ControlCollectionDropDownUIEditor
    {
    	public ExampleDropDownControlCollectionUIEditor() : base()
    	{
    		base.ExcludeForm = true;
    
    		base.CheckControlWidth = 200;
    
    		base.typeExclude.Add(typeof(RadioButton));
    		base.typeExclude.Add(typeof(Label));
    	}
    }
