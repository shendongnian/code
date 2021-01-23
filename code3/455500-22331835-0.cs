    /// <summary>
    /// On Enter Key, it tabs to into next cell.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
    	var uiElement = e.OriginalSource as UIElement;
    	if (e.Key == Key.Enter && uiElement != null)
    	{
    		e.Handled = true;
    		uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    	}
    }
