    public static class DependencyObjectExtensions
    {
    	public static IEnumerable<T> GetChildren<T>(this DependencyObject parent) where T : DependencyObject
    	{
    		List<T> childControls = new List<T>();
    		int count = VisualTreeHelper.GetChildrenCount(parent);
    		for (int i = 0; i < count; i++)
    		{
    			DependencyObject childControl = VisualTreeHelper.GetChild(parent, i);
    			if (childControl is T)
    			{
    				childControls.Add((T)childControl);
    			}
    		}
    		return childControls;
    	}
    }
