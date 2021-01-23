    public void DomeSomeStuff(Grid gridInstance)
    {
        var image = VisualTreeHelper.GetChild(gridInstance, 0) as Image;
        // or var image = gridInstance.Children[0] as Image;
        if (image != null)
            image.Source = ...;
    }
    
