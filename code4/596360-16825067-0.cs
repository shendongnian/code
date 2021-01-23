    public static LocationRect GetMapBounds(DependencyObject obj)
    {
        return (LocationRect)obj.GetValue(MapBoundsProperty);
    }
    
    public static void SetMapBounds(DependencyObject obj, LocationRect value)
    {
        obj.SetValue(MapBoundsProperty, value);
    }
    
    public static readonly DependencyProperty MapBoundsProperty = DependencyProperty.RegisterAttached("MapBounds", typeof(LocationRect), typeof(MapBindings), new PropertyMetadata(null, OnMapBoundsChanged));
    
    private static void OnMapBoundsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var map = d as Bing.Maps.Map;
        if (map != null)
        {
            // sigh.  "Wiggle" the view to force map pins to appear
            LocationRect destRect = e.NewValue as LocationRect;
            if (destRect != null)
            {
                LocationRect wiggleRect = new LocationRect(destRect.Center, destRect.Width + 0.001,
                                                            destRect.Height + 0.001);
    
                map.SetView(wiggleRect, MapAnimationDuration.None);
                map.SetView(destRect, new TimeSpan(0, 0, 1));
            }
        }
    }
