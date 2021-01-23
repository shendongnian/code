        private static System.Drawing.Image DownloadImage(string source)
        {
            System.Drawing.Image image = null;
            // used to fetch content
            var client = new HttpClient();
            // used to store image data
            var memoryStream = new MemoryStream();
            try
            {
                // Blogger tacks on a -h to an image Url to link to an HTML page instead
                if (source.Contains("-h/"))
                    source = source.Replace("-h/", "/");
                // fetch the image
                var response = client.GetAsync(source).Result;
                response.EnsureSuccessStatusCode();
                var contentType = response.Content.Headers.ContentType.MediaType;
                if (!contentType.StartsWith("image/"))
                {
                    Debug.WriteLine(contentType);
                    throw new ArgumentException("Specified source did not return an image");
                }
                var imageStream = response.Content.ReadAsStreamAsync().Result;
                // instantiate a system.drawing.image from the data
                image = System.Drawing.Bitmap.FromStream(imageStream, true, true);
                // save the image data to a memory stream
                image.Save(memoryStream, image.RawFormat);
            }
            catch (HttpRequestException exception)
            {
                // sometimes, we'll get a 404 or other unexpected response
                Debug.WriteLine("{0} {1}", exception.Message, source);
            }
            catch (IOException exception)
            {
                Debug.WriteLine("{0} {1}", exception.Message, source);
            }
            catch (ArgumentException exception)
            {
                // sometimes, an image will link to a web page, resulting in this exception
                Debug.WriteLine("{0} {1}", exception.Message, source);
            }
            finally
            {
                // clean up our disposable resources
                client.Dispose();
                memoryStream.Dispose();
            }
            return image;
        }
