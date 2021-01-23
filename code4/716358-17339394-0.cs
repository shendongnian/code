                            Image myImage = new Image();
                            var stream = await image.OpenAsync(Windows.Storage.FileAccessMode.Read);
                            var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                            await bitmapImage.SetSourceAsync(stream);
                            myImage.Source = bitmapImage;
                            var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
