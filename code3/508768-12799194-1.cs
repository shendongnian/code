	private void OnSemanticZoomViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
	{
	    // only interested in zoomed out->zoomed in transitions
		if (e.IsSourceZoomedInView)
		{
			return;
		}
		// get the selected group
		MyItemGroup selectedGroup = e.SourceItem.Item as MyItemGroup;
		// identify the selected group in the zoomed in data source (here I do it by its name, YMMV)
		ObservableCollection<MyItemGroup> myItemGroups = this.DefaultViewModel["GroupedItems"] as ObservableCollection<MyItemGroup>;
		MyItemGroup myGroup = myItemGroups.First<MyItemGroup>((g) => { return g.Name == selectedGroup.Name; });
		// workaround: need to reset the scroll position first, otherwise ScrollIntoView won't work
		SemanticZoomLocation zoomloc = new SemanticZoomLocation();
		zoomloc.Bounds = new Windows.Foundation.Rect(0, 0, 1, 1);
		zoomloc.Item = myItemGroups[0];
		zoomedInGridView.MakeVisible(zoomloc);
		// now we can scroll to the selected group in the zoomed in view
		zoomedInGridView.ScrollIntoView(myGroup, ScrollIntoViewAlignment.Leading);
	}
