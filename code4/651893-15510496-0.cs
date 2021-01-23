    private void SmartTextElement_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var grid = sender as Grid;
        if (grid == null)
            return;
    
       var item = grid.DataContext as SmartTextItemModel;
       if (item == null)
            return;
    
       item.// Navigate to url...
    }
