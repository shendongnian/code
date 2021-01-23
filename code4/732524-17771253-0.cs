                BitmapImage originalIamge = new BitmapImage();
            originalIamge.BeginInit();
            originalIamge.UriSource = new Uri(ofdOpen.FileName);
            originalIamge.EndInit();
            BitmapSource bitmapSource = new FormatConvertedBitmap(originalIamge, PixelFormats.Bgr32, null, 0);
            wbmap = new WriteableBitmap(bitmapSource);
            h = wbmap.PixelHeight;
            w = wbmap.PixelWidth;
            pixelData = new int[w * h];
            widthInByte = 4 * w;
            wbmap.CopyPixels(pixelData, widthInByte, 0);
            image1.Source = wbmap;
            Point absoluteScreenPos = PointToScreen(Mouse.GetPosition((IInputElement)sender));
            Image img = new Image();
            BitmapImage point = new BitmapImage(
                          new Uri("Images/Dott.png",
                                  UriKind.Relative));
            img.Source = point;
            var rt = ((UIElement)image1).RenderTransform;
            var offsetX = rt.Value.OffsetX;
            var offsetY = rt.Value.OffsetY;
            int newX = (int)Mouse.GetPosition((IInputElement)sender).X;
            int newY = (int)Mouse.GetPosition((IInputElement)sender).Y;
            for (int i = 0; i < 400; i++)
            {
                pixelData[i] = 0x000000ff;
            }
            wbmap.WritePixels(new Int32Rect(newX,newY,10,10), pixelData, widthInByte, 0);
            image1.Source = wbmap;
