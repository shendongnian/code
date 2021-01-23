    // Constructor
    customImageTooltip = new CustomImageTooltip();
    
    foreach (CustomObject o in myCustomObjects)
    {
        customImageTooltip.Subscribe(o, o.Image);
    }
    // Destructor
    foreach (CustomObject o in myCustomObjects)
    {
        customImageTooltip.Unsubscribe(o);
    }
