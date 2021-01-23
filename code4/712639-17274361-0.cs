	List<RectangleF> tabBarButtonFrames = new List<RectangleF>();
	foreach (var view in this.tabBarController.TabBar.Subviews) {
		if (view.ToString().Contains("UITabBarButton"))	{
			tabBarButtonFrames.Add(view.Frame);
		}
		Console.WriteLine(view.ToString() + "\t" + view.Frame.ToString());
	}
