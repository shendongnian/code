        /// <summary>
        /// Get an ImageSource from the ResourceDictionary  referred to by the
        ///     <paramref name="uriDictionary"/>.
        /// </summary>
        /// <param name="keyName">The ResourceDictionary key of the ImageSource to retrieve.</param>
        /// <param name="uriDictionary">The Uri to the XAML file that holds the ResourceDictionary.</param>
        /// <returns><c>null</c> on failure, the requested <c>ImageSource</c> on success.</returns>
        /// <remarks>If the requested resource is an <c>Image</c> instead of an <c>ImageSource</c>,
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
            if (null != blob)
            {
                if (blob is ImageSource)
                {
                    Debug.WriteLine(String.Format("debug: GetImageSource( '{0}', '{1}' )"
                                                + " value is an ImageSource",
                                                  keyName,
                                                  uriDictionary));
                    return blob as ImageSource;
                }
                if (blob is Image)
                {
                    Debug.WriteLine(String.Format("warning: GetImageSource( '{0}', '{1}' )"
                                                + " value is an Image",
                                                keyName,
                                                uriDictionary));
                    Image image = blob as Image;
                    return image.Source;
                }
                Debug.WriteLine(String.Format("error: GetImageSource( '{0}', '{1}' )"
                                                + " value is: {2}",
                                                keyName,
                                                uriDictionary,
                                                blob.GetType().FullName));
            }
            Debug.WriteLine(String.Format("error: GetImageSource( '{0}', '{1}' )"
                                                + " no image.source to return",
                                                keyName,
                                                uriDictionary));
            return null;
        }
