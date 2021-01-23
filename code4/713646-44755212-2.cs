    public static UITestControl EditBox_Password
    {
    	get
    	{
    		if ( mEditBox_Password == null || 	! mEditBox_Password.Exists )
    		{
    			mEditBox_Password = new UITestControl (browserWindow );
    			mEditBox_Password.TechnologyName = "Web";
    			mEditBox_Password.SearchProperties.Add (UITestControl.PropertyNames.ControlType , "Edit");
    			mEditBox_Password.SearchProperties.Add ( UITestControl.PropertyNames.Name , "TxtPassword");
    		}
    		return mEditBox_Password ;
    	}
    }
 
