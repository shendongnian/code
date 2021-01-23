        using (MemoryStream mem = new MemoryStream())
            {
                //Inner Image
                BitmapImage innerImage = new BitmapImage();
                innerImage.SetSource(System.Windows.Application.GetResourceStream(new Uri("test.jpg", UriKind.Relative)).Stream);
                WriteableBitmap wb = new WriteableBitmap(innerImage);
                //Frame Images
                BitmapImage finalImage = new BitmapImage();
                finalImage.SetSource(System.Windows.Application.GetResourceStream(new Uri("White.jpg", UriKind.Relative)).Stream);
                WriteableBitmap wbFinal = new WriteableBitmap(finalImage);
                Image image = new Image();
                image.Height = innerImage.PixelHeight;
                image.Width = innerImage.PixelWidth;
                image.Source = innerImage;
                // TranslateTransform                      
                TranslateTransform tf = new TranslateTransform();
                tf.X = 52;
                tf.Y = 60;
                wbFinal.Render(image, tf);
                wbFinal.Invalidate();
                wbFinal.SaveJpeg(mem, wb.PixelWidth, wb.PixelHeight, 0, 100);
                mem.Seek(0, System.IO.SeekOrigin.Begin);
                // Show image.               
                PagePicture.Source = wbFinal;
            }
