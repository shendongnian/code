    public static IEnumerable<DependencyObject> VisualParents(this DependencyObject element)
	{
		element.ThrowIfNull("element");
		var parent = GetParent(element);
		
		while (parent != null)
		{
			yield return parent;
			parent = GetParent(parent);
		}
	}
	private static DependencyObject GetParent(DependencyObject element)
	{
		var parent = VisualTreeHelper.GetParent(element);
	
        	if (parent == null && element is FrameworkElement)
        		parent = ((FrameworkElement)element).Parent;
	
		return parent;
	}
