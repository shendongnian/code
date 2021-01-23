        public static void SaveBitmapSourceAsJpeg(this BitmapSource image, string fileName, int quality)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.QualityLevel = quality;
                encoder.Save(fileStream);
            }
        }
