    private void UI_Loaded(object sender, RoutedEventArgs e)
    {
    	if (sender is GridSplitter)
    	{
    		Grid ParentGrid = this.ParentOfType<Grid>();
    		SetLocation(ParentGrid);
    	}
    }
    public void SetLocation(Grid p_Layout)
    {
    	int index = Grid.GetColumn(this);
    	ColumnDefinition ColLocation = p_Layout.ColumnDefinitions[index];
    	ColLocation.MinWidth = 10;
    	Left = ColLocation;
    }
