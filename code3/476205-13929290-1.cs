    /// <summary>
        /// Resize image with an URL as source
        /// </summary>
        /// <param name="OriginalFileURL">Link to the image</param>
        /// <param name="heigth">new height</param>
        /// <param name="width">new width</param>
        /// <returns>image with new dimentions</returns>
        public Image resizeImageFromURL(String OriginalFileURL, int heigth, int width)
        {
            return resizeImageFromURL(OriginalFileURL, heigth, width, false, false);
        }
        /// <summary>
        /// Resize image with an URL as source
        /// </summary>
        /// <param name="OriginalFileURL">Link to the image</param>
        /// <param name="heigth">new height</param>
        /// <param name="width">new width</param>
        /// <param name="keepAspectRatio">keep the aspect ratio</param>
        /// <returns>image with new dimentions</returns>
        public Image resizeImageFromURL(String OriginalFileURL, int heigth, int width, Boolean keepAspectRatio)
        {
            return resizeImageFromURL(OriginalFileURL, heigth, width, keepAspectRatio, false);
        }
