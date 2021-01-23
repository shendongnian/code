    public void CreateAd()
            {
                // Create a banner ad for the game.
                int width = 480;
                int height = 80;
                int x = (GraphicsDevice.Viewport.Bounds.Width - width) / 2; // centered on the display
                int y = 720;
    
                bannerAd = adGameComponent.CreateAd(AdUnitId, new Rectangle(x, y, width, height), false);
    
                // Add handlers for events (optional).
                //nextAd.ErrorOccurred += new EventHandler<Microsoft.Advertising.AdErrorEventArgs>(bannerAd_ErrorOccurred);
                // nextAd.AdRefreshed += new EventHandler(bannerAd_AdRefreshed);
    
                // Set some visual properties (optional).
                //bannerAd.BorderEnabled = true; // default is true
                //bannerAd.BorderColor = Color.White; // default is White
                //bannerAd.DropShadowEnabled = true; // default is true
    
                // Provide the location to the ad for better targeting (optional).
                // This is done by starting a GeoCoordinateWatcher and waiting for the location to be available.
                // The callback will set the location into the ad. 
                // Note: The location may not be available in time for the first ad request.
                adGameComponent.Enabled = false;
    
                this.gcw = new GeoCoordinateWatcher();
                this.gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
                this.gcw.Start();
            }
    
            public void removeAd()
            {
                // if only running one ad, use this
                adGameComponent.RemoveAd(bannerAd);
    
                // if running multiple ads, use this
                // adGameComponent.RemoveAll();
            }
    
            /// <summary>
            /// This is called whenever a new ad is received by the ad client.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void bannerAd_AdRefreshed(object sender, EventArgs e)
            {
                Debug.WriteLine("Ad received successfully");
            }
    
            /// <summary>
            /// This is called when an error occurs during the retrieval of an ad.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e">Contains the Error that occurred.</param>
            private void bannerAd_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
            {
                Debug.WriteLine("Ad error: " + e.Error.Message);
            }
    
            private void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                // Stop the GeoCoordinateWatcher now that we have the device location.
                this.gcw.Stop();
    
                bannerAd.LocationLatitude = e.Position.Location.Latitude;
                bannerAd.LocationLongitude = e.Position.Location.Longitude;
    
                AdGameComponent.Current.Enabled = true;
    
                Debug.WriteLine("Device lat/long: " + e.Position.Location.Latitude + ", " + e.Position.Location.Longitude);
            }
