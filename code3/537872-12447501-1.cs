    	public static void SetLabelColumnWidth(PropertyGrid grid, int width)
	{
		if (grid == null)
			throw new ArgumentNullException("grid");
		// get the grid view
		Control view = (Control)grid.GetType().GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(grid);
		// set label width
		FieldInfo fi = view.GetType().GetField("labelWidth", BindingFlags.Instance | BindingFlags.NonPublic);
		fi.SetValue(view, width);
		// refresh
		view.Invalidate();
	}
