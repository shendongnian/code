    private void form1_Load( object sender , EventArgs e )
    {
    	//this.MouseWheel -= When_MouseWheel;
    	this.MouseWheel += When_MouseWheel;
    }
    void When_MouseWheel( object sender , MouseEventArgs e )
    {
    	if ( this.contextMenuStrip1.IsDropDown ) {
             //this.contextMenuStrip1.Focus();
   		     if ( e.Delta > 0 ) SendKeys.SendWait( "{UP}" );
    		 else SendKeys.SendWait( "{DOWN}" );  		 
    	}
    }
