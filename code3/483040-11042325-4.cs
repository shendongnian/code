        /// <summary>
        /// Get an ImageSource from the ResourceDictionary  referred to by the
        ///     <paramref name="uriDictionary"/>.
        /// </summary>
        /// <param name="keyName">The ResourceDictionary key of the ImageSource
        ///     to retrieve.</param>
        /// <param name="uriDictionary">The Uri to the XAML file that holds
        ///     the ResourceDictionary.</param>
        /// <returns><c>null</c> on failure, the requested <c>ImageSource</c>
        ///     on success.</returns>
        /// <remarks>If the requested resource is an <c>Image</c> instead of
        ///     an <c>ImageSource</c>,
        /// then the <c>image.Source</c> is returned.</remarks>
        public static ImageSource GetImageSource(String keyName, Uri uriDictionary)
        {
            if (String.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            if (null == uriDictionary)
                throw new ArgumentNullException("uriDictionary");
            ResourceDictionary imagesDictionary = new ResourceDictionary();
            imagesDictionary.Source = uriDictionary;
            var var = imagesDictionary[keyName];
            Object blob = imagesDictionary[keyName];
            Debug.WriteLine(String.Format(
                "error: GetImageSource( '{0}', '{1}' )"
                + " value is: {2}",
                keyName,
                uriDictionary,
                (null == blob) ? "null" : blob.GetType().FullName));
            if (null != blob)
            {
                if (blob is ImageSource)
                {
                    return blob as ImageSource;
                }
                if (blob is Image)
                {
                    Image image = blob as Image;
                    return image.Source;
                }
                if (blob is System.Drawing.Image)
                {
                    System.Drawing.Image dImage = blob as System.Drawing.Image;
                    MemoryStream mem = new MemoryStream();
                    dImage.Save(mem, System.Drawing.Imaging.ImageFormat.MemoryBmp);
                    mem.Position = 0;
                    BitmapDecoder decode = new BmpBitmapDecoder(
                        mem,
                        BitmapCreateOptions.None,
                        BitmapCacheOption.None);
                    return decode.Frames[0];
                }
                Debug.WriteLine(String.Format(
                    "error: GetImageSource( '{0}', '{1}' )"
                    + " can't handle type: {2}",
                    keyName,
                    uriDictionary,
                    blob.GetType().FullName));
            }
            return null;
        }
