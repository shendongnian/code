    protected override void OnMouseMove(MouseEventArgs e)
    {
    	base.OnMouseMove(e);
    
    	if (this.IsMouseCaptured)
    	{
    		bool isInside = false;
    
    		VisualTreeHelper.HitTest(
    			this,
    			d =>
    			{
    				if (d == this)
    				{
    					isInside = true;
    				}
    
    				return HitTestFilterBehavior.Stop;
    			},
    			ht => HitTestResultBehavior.Stop,
    			new PointHitTestParameters(e.GetPosition(this)));
    
    		if (isInside)
    		{
    			Debug.WriteLine("Inside");
    		}
    		else
    		{
    			Debug.WriteLine("Outside");
    		}
    	}
    }
