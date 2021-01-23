    ContainerVisual smallerPage = new ContainerVisual( );
    
    DrawingVisual pageVisual = page.Visual as DrawingVisual;
    
    if ( pageVisual != null && pageVisual.Parent != null )
    
    {
    
    ContainerVisual parent = pageVisual.Parent as ContainerVisual;
    
    parent.Children.Remove( pageVisual );
    
    }
    
    smallerPage.Children.Add( page.Visual );
