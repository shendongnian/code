     bool _isDefaultItemAdded = false
    private void QuotePreview_Loaded(object sender, RoutedEventArgs e)
    {
        if(!_isDefaultItemAdded)
        {
           //Adds item to Debugging list
             _selectionList.SelectedOptions.Add(
            new Selection
            {
                ModelNumber = "this",
                Description = "really",
                Price = "sucks"
            });
            _isDefaultItemAdded = true;
        }
       
    }
