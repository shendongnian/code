    /// <summary>
    /// Sets TileSource as the exclusive MapTileLayer
    /// </summary>
    private void RefreshTileSource()
    {
        for (var i = Map.Children.Count - 1; i >= 0; i--)
        {
            MapTileLayer tileLayer = Map.Children[i] as MapTileLayer;
            if (tileLayer != null)
            {
                Map.Children.RemoveAt(i);
            }
        }
    
        // Tiles
        MapTileLayer layer = new MapTileLayer();
        layer.TileSources.Add(ViewModel.TileSource);
        Map.Children.Add(layer);
    
        // Constrain map to area with custom tiles
        MapMode mode = new MapMode();
        mode.SetZoomRange(ViewModel.TileSource.ZoomRange);
        if (ViewModel.MapBounds.North > ViewModel.MapBounds.South)
            mode.LatitudeRange = new Range<double>(ViewModel.MapBounds.South, ViewModel.MapBounds.North);
        else
            mode.LatitudeRange = new Range<double>(ViewModel.MapBounds.North, ViewModel.MapBounds.South);
        if (ViewModel.MapBounds.West > ViewModel.MapBounds.East)
            mode.LongitudeRange = new Range<double>(ViewModel.MapBounds.East, ViewModel.MapBounds.West);
        else
            mode.LongitudeRange = new Range<double>(ViewModel.MapBounds.West, ViewModel.MapBounds.East);
        Map.Mode = mode;
    }
