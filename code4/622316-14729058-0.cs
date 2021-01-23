        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            byte[] bytesArray = null;
 
            if (value != null && value is byte[] && (value as byte[]).Length > 0)
            {
                bytesArray = value as byte[];
            }
            else
            {
                //TODO: Add default Image here
            }
 
            using (MemoryRandomAccessStream memoryStream = new MemoryRandomAccessStream(bytesArray))
            {
                this.image = new BitmapImage();
                this.SetImageSource(memoryStream);
                return image;
            }
        }
 
        /// <summary>
        /// Sets the image source.
        /// </summary>
        /// <param name="memoryStream">The memory stream.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private async void SetImageSource(MemoryRandomAccessStream memoryStream)
        {
            await this.image.SetSourceAsync(memoryStream);
        }
