            using (var sourceStream = await imgeTOBytes.OpenAsync(FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(sourceStream);
                double widthRatio = (double)maxWidth / decoder.OrientedPixelWidth;
                double heightRatio = (double)maxHeight / decoder.OrientedPixelHeight;
                double scaleRatio = Math.Min(widthRatio, heightRatio);
                uint aspectHeight = (uint)Math.Floor((double)decoder.OrientedPixelHeight * scaleRatio);
                uint aspectWidth = (uint)Math.Floor((double)decoder.OrientedPixelWidth * scaleRatio);
                BitmapTransform transform = new BitmapTransform() { InterpolationMode = BitmapInterpolationMode.Fant, ScaledHeight = aspectHeight, ScaledWidth = aspectWidth };
                PixelDataProvider pixelData = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Premultiplied,
                    transform,
                    ExifOrientationMode.RespectExifOrientation,
                    ColorManagementMode.DoNotColorManage);
                using (var destinationStream = await imgeTOBytes.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, destinationStream);
                    encoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight, aspectWidth, aspectHeight, 96, 96, pixelData.DetachPixelData());
                    await encoder.FlushAsync();
                }
            }`
