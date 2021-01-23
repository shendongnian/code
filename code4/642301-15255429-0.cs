    public class ImageResizer_Abridged
    {
        private readonly UIImage originalImage;
        private UIImage modifiedImage;
        public ImageResizer_Abridged(UIImage image)
        {
            this.originalImage = image;
            this.modifiedImage = image;
        }
        /// <summary>
        /// stretch resize
        /// </summary>
        public void Resize(float width, float height)
        {
            UIGraphics.BeginImageContext(new SizeF(width, height));
            //
            var oldImage = this.modifiedImage;
            this.modifiedImage.Draw(new RectangleF(0, 0, width, height));
            this.modifiedImage = UIGraphics.GetImageFromCurrentImageContext();
            oldImage.Dispose();
            //
            UIGraphics.EndImageContext();
        }
        public UIImage OriginalImage
        {
            get
            {
                return this.originalImage;
            }
        }
        public UIImage ModifiedImage
        {
            get
            {
                return this.modifiedImage;
            }
        }
    }
