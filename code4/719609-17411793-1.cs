    // Once we have read in ALL of the points in the track, add the polyline
    // to the map.
    GMap.Add(new PolyLine(Coords, Color.Red, 100f, 2, new InfoWindow("")));
    // Lastly, identify the center of the polyline and add that point:
    GMap.Center = Coords[Coords.Count / 2];
    GMap.ZoomLevel = 12;
    GMap.Add(new ImageMarker(GMap.Center, " ", new InfoWindow(""), 
