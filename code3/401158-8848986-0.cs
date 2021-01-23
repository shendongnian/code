            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];
            // Define the image palette
            BitmapPalette myPalette = BitmapPalettes.Halftone256;
            // Creates a new empty image with the pre-defined palette
            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);
            FileStream stream = new FileStream("new.jpg", FileMode.Create);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.FlipHorizontal = true;
            encoder.FlipVertical = false;
            encoder.QualityLevel = 30;
            encoder.Rotation = Rotation.Rotate90;
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
