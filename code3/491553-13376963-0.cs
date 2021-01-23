        private void pinCurrentMapCenterAsSecondaryTile() {
			try {
				var usCultureInfo = new CultureInfo("en-US");
				var latitude = map.Center.Latitude.ToString(usCultureInfo.NumberFormat);
				var longitude = map.Center.Longitude.ToString(usCultureInfo.NumberFormat);
				var zoom = map.ZoomLevel.ToString(usCultureInfo.NumberFormat);
				var tileParam = "Lat=" + latitude + "&Lon=" + longitude + "&Zoom=" + zoom;
				if (null != App.CheckIfTileExist(tileParam)) return; // tile for exactly this view already exists
				using (var store = IsolatedStorageFile.GetUserStoreForApplication()) {
					var fileName = "/Shared/ShellContent/" + tileParam + ".jpg";
					if (store.FileExists(fileName)) {
						store.DeleteFile(fileName);
					}
                    // hide pushpins and stuff
					foreach (var layer in map.Children.OfType<MapLayer>()) {
						layer.Visibility = Visibility.Collapsed;
					}
					using (var saveFileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, store)) {
						var wb = new WriteableBitmap(173, 173);
						b.Render(
                            map,// the map defined in XAML
                            new TranslateTransform {  
                                // use the transformation to clip the center of the current map-view
							    X = -(map.ActualWidth - 173)/2,
							    Y = -(map.ActualHeight - 173)/2,
                        });
						wb.Invalidate();
						wb.SaveJpeg(saveFileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
					}
					foreach (var layer in map.Children.OfType<MapLayer>()) {
						layer.Visibility = Visibility.Visible;
					}
				}
				
				ShellTile.Create(
					new Uri("/MainPage.xaml?" + tileParam, UriKind.Relative),
					new StandardTileData {
						BackTitle = "ApplicationName",
						Count = 0,
                        // You can only load images from the web or isolated storage onto secondary tiles
						BackgroundImage = new Uri("isostore:/Shared/ShellContent/" + tileParam + ".jpg", UriKind.Absolute),
					});
			} catch (Exception e) {
				// yeah, this is 7331!!11elfelf
			}
		}
