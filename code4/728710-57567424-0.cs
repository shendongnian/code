    gMapControl1.MouseClick += new MouseEventHandler(map_mouseCLick);
    private void map_mouseCLick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lon = point.Lng;
                //this the the values of latitude in double when you click 
                double newPointLat = lat;
                //this the the values of longitude in double when you click 
                double newPointLong = lon;
            }
        }
