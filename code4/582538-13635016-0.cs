            MapPolyline line = new MapPolyline();
            line.StrokeColor = Colors.Red;
            line.StrokeThickness = 10;
            line.Path.Add(new GeoCoordinate(47.6602, -122.098358));
            line.Path.Add(new GeoCoordinate(47.561482, -122.071544));
            MyMap.MapElements.Add(line);
