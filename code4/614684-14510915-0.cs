    private void myGrid_Loaded(object sender, RoutedEventArgs e)
    {
    	DataGrid dg = sender as DataGrid;
    	Border border = VisualTreeHelper.GetChild(dg, 0) as Border;
    	ScrollViewer scrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer;
    	Grid grid = VisualTreeHelper.GetChild(scrollViewer, 0) as Grid;
    	Button button = VisualTreeHelper.GetChild(grid, 0) as Button;
    
    	if (button != null && button.Command != null && button.Command == DataGrid.SelectAllCommand)
    	{
    		button.Click += new RoutedEventHandler(button_Click);
    	}         
    }
    
    void button_Click(object sender, RoutedEventArgs e)
    {     
    	myGrid.Focus();           
    }
