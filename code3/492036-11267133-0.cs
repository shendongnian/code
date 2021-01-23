        using (var colorSpace = CGColorSpace.CreateDeviceRGB())
        using (var context = new CGBitmapContext(
            bytes, width, height, bitsPerComponent, bytesPerRow, 
            colorSpace, CGBitmapFlags.ByteOrder32Big | CGBitmapFlags.PremultipliedLast))
        {
            var drawRect = new RectangleF(-rectangle.X, -rectangle.Y, image.CGImage.Width, image.CGImage.Height);
            context.ClipToRect(new RectangleF(0, 0, width, height));
            context.DrawImage(drawRect, image.CGImage);
        }
