	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		MegaWidget MWidget = (MegaWidget)value;
		Location loc = MWidget.Locations[(string)parameter];
		List<ListBoxItem> displayContent = new List<ListBoxItem>();
		
		foreach (Part item in loc.Contents)
		{
			ListBoxItem lbi = new ListBoxItem();
			lbi.Content = item.Name;
			displayContent.Add(lbi);
		}
		
		return displayContent;
	}
