    private void GPS_PositionReceived(string Lat, string Lon)
    {
        arrLon = Lon.Split(new char[] { '°', '"' }, StringSplitOptions.RemoveEmptyEntries);
        dblLon = double.Parse(arrLon[0]) + double.Parse(arrLon[1], new System.Globalization.NumberFormatInfo()) / 60;
        deciLon = arrLon[2] == "E" ? dblLon : -dblLon;
        //some more code 
        // LOAD FORM 1
        // CLOSE THIS FORM (FORM 2)
    }
