        private void GenerateMap(List<MapValues> mapInfo)
        {
            gMapControl1.SetCurrentPositionByKeywords("USA");
            gMapControl1.MinZoom = 3;
            gMapControl1.MaxZoom = 17;
            gMapControl1.Zoom = 4;
            gMapControl1.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Position = new GMap.NET.PointLatLng(29.60862, -82.43821);
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.WindowsForms.GMapOverlay address_overlay = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "Address1");
            foreach (MapValues info in mapInfo)
            {
                PointLatLng pnl = new PointLatLng(Convert.ToDouble(info.Latitude), Convert.ToDouble(info.Longitude));
                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(pnl);
                MarkerTooltipMode mode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipMode = mode;
                marker.ToolTipText = info.City + ", " + info.Address + ", " + info.ZipCode + ", " + info.State;
                address_overlay.Markers.Add(marker);
            }
            gMapControl1.Overlays.Add(address_overlay);
        }
