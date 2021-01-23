    // System.Windows.Data.MultiBinding
    /// <summary>Gets or sets a value that indicates whether to raise the <see cref="E:System.Windows.FrameworkElement.SourceUpdated" /> event when a value is transferred from the binding target to the binding source.</summary>
    /// <returns>true if the <see cref="E:System.Windows.FrameworkElement.SourceUpdated" /> event will be raised when the binding source value is updated; otherwise, false. The default value is false.</returns>
    [DefaultValue(false)]
    public bool NotifyOnSourceUpdated
    {
    	get
    	{
    		return base.TestFlag(BindingBase.BindingFlags.NotifyOnSourceUpdated);
    	}
    	set
    	{
    		bool flag = base.TestFlag(BindingBase.BindingFlags.NotifyOnSourceUpdated);
    		if (flag != value)
    		{
    			base.CheckSealed();
    			base.ChangeFlag(BindingBase.BindingFlags.NotifyOnSourceUpdated, value);
    		}
    	}
    }
