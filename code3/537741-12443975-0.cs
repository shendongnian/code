        /// <summary>
        /// Copies an image from the internet (http protocol) locally to the AppData LocalFolder.  This is used by some methods 
        /// (like the SecondaryTile constructor) that do not support referencing images over http but can reference them using 
        /// the ms-appdata protocol.  
        /// </summary>
        /// <param name="internetUri">The path (URI) to the image on the internet</param>
        /// <param name="uniqueName">A unique name for the local file</param>
        /// <returns>Path to the image that has been copied locally</returns>
        private async Task<Uri> GetLocalImageAsync(string internetUri, string uniqueName)
        {
            if (string.IsNullOrEmpty(internetUri))
            {
                return null;
            }
            using (var response = await HttpWebRequest.CreateHttp(internetUri).GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var desiredName = string.Format("{0}.jpg", uniqueName);
                    var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(desiredName, CreationCollisionOption.ReplaceExisting);
                    using (var filestream = await file.OpenStreamForWriteAsync())
                    {
                        await stream.CopyToAsync(filestream);
                        return new Uri(string.Format("ms-appdata:///local/{0}.jpg", uniqueName), UriKind.Absolute);
                    }
                }
            }
        }
 
