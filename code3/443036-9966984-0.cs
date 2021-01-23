    protected override void OnMouseMove(MouseEventArgs e)
    {
    	base.OnMouseMove(e);
    
    	if (this.IsMouseCaptured)
    	{
    		HitTestResult ht = VisualTreeHelper.HitTest(this, e.GetPosition(this));
    		if (ht != null)
    		{
    			DependencyObject current = ht.VisualHit;
    			while (current != this && current != null)
    			{
    				current = VisualTreeHelper.GetParent(current);
    			}
    
    			if (current == this)
    			{
    				Debug.WriteLine("Inside");
    				return;
    			}
    		}
    				
    		Debug.WriteLine("Outside");
    	}
    }
