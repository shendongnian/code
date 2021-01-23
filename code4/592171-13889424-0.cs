    private void addBtn_Click(object sender, EventArgs e)
        {
            string wayName = nameTxtBox.Text;
            double lat = Convert.ToDouble( latTxtBox.Text);
            float wayLat = (float)lat;
            double lon = Convert.ToDouble( longTxtBox.Text);
            float wayLong = (float)lon;
            double ele = Convert.ToDouble(elevTxtBox.Text);
            float wayEle = (float)ele;
            WayPoint wp = new WayPoint(wayName, wayLat, wayLong, wayEle);
            GPSDataPoint gdp = new GPSDataPoint();
            gdp.Add(wp);
            
            //Do something with your gdp variable or use the public on you have declared instead
            //gpsdp.Add(wp);
         }
