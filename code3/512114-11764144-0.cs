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
