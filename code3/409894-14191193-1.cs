    ItemViewerView ivv = ((Grid)(((UserControl)(cvc.Content)).Content)).Children[0] as ItemViewerView;
    Grid g = (((Grid)ivv.Content).Children[0] as Grid);
    ContentControl cc1 = (g.Children[0] as ContentControl);
    if (cc1 != null)
    {
        Canvas cvs = cc1.Content as Canvas;
        if (cvs != null && cvs.Children.Count > 0)
        {
            var contentControl = cvs.Children[0] as ContentControl;
            if (contentControl != null)
            {
                MultiScaleImage x = contentControl.Content as MultiScaleImage;
                bool isIdle = x.Source != null && !x.IsDownloading && x.IsIdle;
                // This could be more precise, but the origin is by default set to 99999 when a new image is loaded in - we're watching for when this value changes.                
                bool inViewPort = x.SubImages[x.SubImages.Count - 1].ViewportOrigin.X < 999999;
                // if both of these boolean values are true, then the images will be displaying on the screen.
            }
        }
     }
