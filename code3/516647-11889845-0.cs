        StorageFile file;
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            string filePath = @"Assets\dock.jpg";
            file = await InstallationFolder.GetFileAsync(filePath);
            IRandomAccessStream dockpic = await file.OpenAsync(0);
            BitmapImage dockimage = new BitmapImage();
            dockimage.SetSource(dockpic);
            Rectangle blueRectangle = new Rectangle();
            blueRectangle.Height = 100;
            blueRectangle.Width = 200;
            // Create an ImageBrush
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = dockimage;
            // Fill rectangle with an ImageBrush
            blueRectangle.Fill = imgBrush;
            paintCanvas.Children.Add(blueRectangle);
