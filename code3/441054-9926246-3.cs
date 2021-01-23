    ControlTemplate controlTemplate = 
        FindResource("Template") as ControlTemplate; 
                
    ContentControl content = new ContentControl();
    content.Template = controlTemplate;
                
    // ensure control has dimensions
    content.Measure(new Size(200, 200));
    content.Arrange(new Rect(0, 0, 200, 200));
    
    RenderTargetBitmap render =
        new RenderTargetBitmap((int)content.ActualWidth, (int)content.ActualHeight, 120, 96, PixelFormats.Pbgra32);
    
    render.Render(content);
    
    RibbonApplicationMenuItem menu = new RibbonApplicationMenuItem();
    menu.ImageSource = render;
