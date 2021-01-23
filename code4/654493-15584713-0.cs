    class ImageAndThumb
    {
        public Image Thumb;
        public Image Big;
        private string ImagePath;
        public ImageAndThumb(string fileName)
        {         
            ImagePath = fileName;
            Image image = Image.FromFile(fileName)
            Image thumb = img.GetThumbnailImage(200, 200, ()=>false, IntPtr.Zero);
        }
        public Image LoadBigImage()
        {
            Big = Image.FromFile(ImagePath);
            return Big;
        }
        public void UnloadImage()
        {
            Big = null;
        }
    
    }
