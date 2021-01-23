    public static T FindChildOfType<T>(this DependencyObject dpo) where T : DependencyObject
    {
    	int cCount = VisualTreeHelper.GetChildrenCount(dpo);
    	for (int i = 0; i < cCount; i++)
    	{
    		var child = VisualTreeHelper.GetChild(dpo, i);
    		if (child.GetType() == typeof(T))
    		{
    			return child as T;
    		}
    		else
    		{
    			var subChild = child.FindChildOfType<T>();
    			if (subChild != null) return subChild;
    		}
    	}
    	return null;
    }
