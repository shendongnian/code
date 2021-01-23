        private List<Image> GetImages(string imageFile)
        {
            var images = new List<Image>();
            Image rootImage = Image.FromFile(imageFile);
            for (int i = 0; i < 6; i++)
            {
                Image image = CropImage(rootImage, new Rectangle(10 + i * 60, 0, 70, 60));
                images.Add(image);
            }
            return images;
        }
        private static Image CropImage(Image image, Rectangle area)
        {
            var bmpImage = new Bitmap(image);
            Bitmap bmpCrop = bmpImage.Clone(area, bmpImage.PixelFormat);
            return (bmpCrop);
        }
