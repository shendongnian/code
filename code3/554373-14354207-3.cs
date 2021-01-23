            int zoom = 6;
            Tile googleTile = new Tile(10,24);
            Tile tmsTile = GlobalMercator.ToTmsTile(googleTile, zoom);
            Rect r3 = GlobalMercator.TileLatLonBounds(tmsTile, zoom);
            var tl = GlobalMercator.LatLonToMeters(r3.Top, r3.Left);
            var br = GlobalMercator.LatLonToMeters(r3.Bottom, r3.Right);
            Debug.WriteLine("{0:0.000}  {1:0.000}", tl.X, tl.Y); 
            Debug.WriteLine("{0:0.000}  {1:0.000}", br.X, br.Y);
            // -13775787.000  4383205.000
            // -13149615.000  5009376.500
