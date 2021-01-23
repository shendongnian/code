    DependencyObject dgColumnHeader = GetYourColumnHeader();
    var yourAutoCompleteTextBox = FindVisualChild<AutoCompleteTextBox>(dgColumnHeader);
    public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
    	for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
    	{
    		DependencyObject child = VisualTreeHelper.GetChild(parent, i);
    		if (child != null && child is T)
    			return (T)child;
    		else
    		{
    			T childOfChild = FindVisualChild<T>(child);
    			if (childOfChild != null)
    				return childOfChild;
    		}
    	}
    	return null;
    }
