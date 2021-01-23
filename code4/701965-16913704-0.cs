    private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        var path = e.OriginalSource as Path;
        
        if(path != null)
        {
            //use path.Name or path.Tag
        }
    }
