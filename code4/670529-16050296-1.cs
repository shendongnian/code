    public WriteableBitmap SaveAsWriteableBitmap(Canvas surface)
    {
        if (surface == null) return null;
     
        // Save current canvas transform
        Transform transform = surface.LayoutTransform;
        // reset current transform (in case it is scaled or rotated)
        surface.LayoutTransform = null;
    
        // Get the size of canvas
        Size size = new Size(surface.ActualWidth, surface.ActualHeight);
        // Measure and arrange the surface
        // VERY IMPORTANT
        surface.Measure(size);
        surface.Arrange(new Rect(size));
    
        // Create a render bitmap and push the surface to it
        RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
          (int)size.Width, 
          (int)size.Height, 
          96d, 
          96d, 
          PixelFormats.Pbgra32);
        renderBitmap.Render(surface);
    
        //Restore previously saved layout
        surface.LayoutTransform = transform;
        //create and return a new WriteableBitmap using the RenderTargetBitmap
        return new WriteableBitmap(renderBitmap);
    
    }
