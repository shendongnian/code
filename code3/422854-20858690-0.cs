            var fileName = String.Format("{0:}.jpg", DateTime.Now.Ticks);
            WriteableBitmap bmpCurrentScreenImage = new WriteableBitmap(480, 552);
            bmpCurrentScreenImage.Render(yourCanvas, new MatrixTransform());
            bmpCurrentScreenImage.Invalidate();
            SaveToMediaLibrary(bmpCurrentScreenImage, fileName, 100);
        public void SaveToMediaLibrary(WriteableBitmap bitmap, string name, int quality)
        {
            using (var stream = new MemoryStream())
            {
                // Save the picture to the Windows Phone media library.
                bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
                stream.Seek(0, SeekOrigin.Begin);
                new MediaLibrary().SavePicture(name, stream);
            }
        }
