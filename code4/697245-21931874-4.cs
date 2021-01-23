    private void Map_OnTap(object sender, GestureEventArgs e)
    {
        var point = e.GetPosition(Map);
        //var coordinate = Map.ConvertViewportPointToGeoCoordinate(point);
    
        int elements = Map.GetMapElementsAt(point).Count;
        System.Diagnostics.Debug.WriteLine(string.Format("Hit {0} map element(s)", elements));
    }
