    private StackPanel _stackPanelContainer = MainStackPanel; // Get a reference to the StackPanel w/ all the UI controls
    // Since StackPanel contains a "List" of children, you can iterate through each UI Control inside it
    //
    foreach (var child in _stackPanelContainer.Children)
    {
       // Check to see if the current UI Control being iterated over is a DataGrid
       //
       if (child is DataGrid)
       {
           // perform DataGrid printing here, using the child variable
       }
    }
