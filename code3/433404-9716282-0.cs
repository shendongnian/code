	public static T FindVisualChild<T>(DependencyObject obj, string name)
		where T : DependencyObject
	{
		var count = VisualTreeHelper.GetChildrenCount(obj);
		for(int i = 0; i < count; i++)
		{
			var child = VisualTreeHelper.GetChild(obj, i);
			if(child != null)
			{
				var res = child as T;
				if(res != null && (string)res.GetValue(FrameworkElement.NameProperty) == name)
				{
					return res;
				}
				res = FindVisualChild<T>(child, name);
				if(res != null) return res;
			}
		}
		return null;
	}
