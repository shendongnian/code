            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                // Request the current position
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                );
                string latitude = geoposition.Coordinate.Latitude.ToString("0.00");
                string longitude = geoposition.Coordinate.Longitude.ToString("0.00");                 
                
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    MessageBox.Show("Location is disabled in phone settings.", "Can't Detect Location", MessageBoxButton.OK);
                    
                }
                //else
                {
                    // something else happened acquring the location
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
