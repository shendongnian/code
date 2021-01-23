    protected virtual void SetVisibleCore(bool value)
    {
    	try
    	{
    		HandleCollector.SuspendCollect();
    		if (this.GetVisibleCore() != value)
    		{
    			if (!value)
    			{
    				this.SelectNextIfFocused();
    			}
    			bool flag = false;
    			if (this.GetTopLevel())
    			{
    				if (this.IsHandleCreated || value)
    				{
    					SafeNativeMethods.ShowWindow(new HandleRef(this, this.Handle), value ? this.ShowParams : 0);
    				}
    			}
    			else
    			{
    				if (this.IsHandleCreated || (value && this.parent != null && this.parent.Created))
    				{
    					this.SetState(2, value);
    					flag = true;
    					try
    					{
    						if (value)
    						{
    							this.CreateControl();
    						}
    						SafeNativeMethods.SetWindowPos(new HandleRef(this.window, this.Handle), NativeMethods.NullHandleRef, 0, 0, 0, 0, 23 | (value ? 64 : 128));
    					}
    					catch
    					{
    						this.SetState(2, !value);
    						throw;
    					}
    				}
    			}
    			if (this.GetVisibleCore() != value)
    			{
    				this.SetState(2, value);
    				flag = true;
    			}
    			if (flag)
    			{
    				using (new LayoutTransaction(this.parent, this, PropertyNames.Visible))
    				{
    					this.OnVisibleChanged(EventArgs.Empty);
    				}
    			}
    			this.UpdateRoot();
    		}
    		else
    		{
    			if (this.GetState(2) || value || !this.IsHandleCreated || SafeNativeMethods.IsWindowVisible(new HandleRef(this, this.Handle)))
    			{
    				this.SetState(2, value);
    				if (this.IsHandleCreated)
    				{
    					SafeNativeMethods.SetWindowPos(new HandleRef(this.window, this.Handle), NativeMethods.NullHandleRef, 0, 0, 0, 0, 23 | (value ? 64 : 128));
    				}
    			}
    		}
    	}
    	finally
    	{
    		HandleCollector.ResumeCollect();
    	}
    }
