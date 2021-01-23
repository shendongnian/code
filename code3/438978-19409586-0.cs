    /// <summary>
    /// Method that forces the control to resize itself when in AutoSize following
    /// a change in its state that affect the size.
    /// </summary>
    private void ResizeForAutoSize()
    {
    	if( this.AutoSize )
    		this.SetBoundsCore( this.Left, this.Top, this.Width, this.Height,
    				 	BoundsSpecified.Size );
    }
    
    /// <summary>
    /// Calculate the required size of the control if in AutoSize.
    /// </summary>
    /// <returns>Size.</returns>
    private Size GetAutoSize()
    {
    	//	Do your specific calculation here...
    	Size size = new Size( 100, 20 );
    
    	return size;
    }
    
    /// <summary>
    /// Retrieves the size of a rectangular area into which
    /// a control can be fitted.
    /// </summary>
    public override Size GetPreferredSize( Size proposedSize )
    {
    	return GetAutoSize();
    }
    
    /// <summary>
    /// Performs the work of setting the specified bounds of this control.
    /// </summary>
    protected override void SetBoundsCore( int x, int y, int width, int height,
  			BoundsSpecified specified )
    {
    	//	Only when the size is affected...
    	if( this.AutoSize && ( specified & BoundsSpecified.Size ) != 0 )
    	{
    		Size size = GetAutoSize();
    
    		width	= size.Width;
    		height	= size.Height;
    	}
    
    	base.SetBoundsCore( x, y, width, height, specified );
    }
