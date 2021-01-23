    static ListBoxItem()
    {
    	ListBoxItem.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof(ListBoxItem), new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(ListBoxItem.OnIsSelectedChanged)));
    	ListBoxItem.SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(ListBoxItem));
    	ListBoxItem.UnselectedEvent = Selector.UnselectedEvent.AddOwner(typeof(ListBoxItem));
        ...
    }
    private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	ListBoxItem listBoxItem = d as ListBoxItem;
    	bool flag = (bool)e.NewValue;
    	Selector parentSelector = listBoxItem.ParentSelector;
    	if (parentSelector != null)
    	{
    		parentSelector.RaiseIsSelectedChangedAutomationEvent(listBoxItem, flag);
    	}
    	if (flag)
    	{
    		listBoxItem.OnSelected(new RoutedEventArgs(Selector.SelectedEvent, listBoxItem));
    	}
    	else
    	{
    		listBoxItem.OnUnselected(new RoutedEventArgs(Selector.UnselectedEvent, listBoxItem));
    	}
    	listBoxItem.UpdateVisualState();
    }
