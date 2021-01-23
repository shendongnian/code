    private void WindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
    {
    	//Reset scroll view size
    	int count = MainFlipView.Items.Count;
    	for(int i = 0; i < count; i++)
    	{
    		var flipViewItem = MainFlipView.ItemContainerGenerator.ContainerFromIndex((i));
    		var scrollViewItem = FindFirstElementInVisualTree<ScrollViewer>(flipViewItem);
    		if (scrollViewItem is ScrollViewer)
    		{
    			ScrollViewer scroll = (ScrollViewer)scrollViewItem;
    			scroll.Height = e.Size.Height; //Reset width and height to match the new size
    			scroll.Width = e.Size.Width;
    			scroll.ZoomToFactor(1.0f);//Zoom to default factor
    		}
    	}
    }
