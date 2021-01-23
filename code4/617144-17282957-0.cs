        public HttpResponseMessage Get(string imageIDsList)
        {
            var imageIDs = imageIDsList.Split(',').Select(_ => int.Parse(_));
            var any = _dataContext.DeepZoomImages.Select(_ => _.ImageID).Where(_ => imageIDs.Contains(_)).Any();
            if (!any)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            var dzImages = _dataContext.DeepZoomImages.Where(_ => imageIDs.Contains(_.ImageID));
            var streamContent = new PushStreamContent((outputStream, httpContext, transportContent) =>
                {
                    using (var zipFile = new ZipFile())
                    {
                        foreach (var dzImage in dzImages)
                        {
                            var bitmap = GetFullSizeBitmap(dzImage);
                            var memoryStream = new MemoryStream();
                            bitmap.Save(memoryStream, ImageFormat.Jpeg);
                            memoryStream.Position = 0;
                            var fileName = string.Format("{0}.jpg", dzImage.ImageName);
                            zipFile.AddEntry(fileName, memoryStream);
                        }
                        zipFile.Save(outputStream); //Null Reference Exception
                    }
                });
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = string.Format("{0}_images.zip", dzImages.Count()),
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = streamContent
                };
          
            return response;
        }
