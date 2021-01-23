    public class ImageData
    {
        /// <summary>
        /// Relative path to image
        /// </summary>
        public string ImageSourceUri { get; set; }
        public ImageSource ImageSource
        {
            get { return new BitmapImage(App.GetPathUri(ImageSourceUri)); }
        }
    }
