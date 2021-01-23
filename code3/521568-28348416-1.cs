    public async Task<IHttpActionResult> Post(int id, string type)
    {
        // Check if the request contains multipart/form-data.
        if(!Request.Content.IsMimeMultipartContent("form-data"))
            return BadRequest("Unsupported media type");
        try
        {
            var azureManager = new AzureManager();
            var imageManager = new ImageManager();
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var assets = new List<Asset>();
            foreach (var file in provider.Contents)
            {
                var stream = await file.ReadAsStreamAsync();
                var guid = Guid.NewGuid();
                string blobName = guid.ToString();
                await azureManager.UploadAsync(blobName, stream);
                var asset = new Asset
                {
                    PropertyId = id,
                    FileId = guid,
                    FileName = file.Headers.ContentDisposition.FileName.Trim('\"').ToLower(),
                    FileSize = file.Headers.ContentLength ?? 0,
                    MimeType = file.Headers.ContentType.MediaType.ToLower()
                };
                if (type == "photos")
                {
                    asset.Type = AssetType.Photo;
                    // Resize and crop copies to 16:9
                    using (MemoryStream thumb = imageManager.ResizeImage(stream, 320, 180))
                    {
                        await azureManager.UploadAsync(blobName, thumb, BlobContainers.Thumbs);
                    }
                    using (MemoryStream photo = imageManager.ResizeImage(stream, 1024, 576))
                    {
                        await azureManager.UploadAsync(blobName, photo, BlobContainers.Photos);
                    }
                }
                else
                    asset.AssumeType();
                assets.Add(asset);
            }
            db.Assets.AddRange(assets);
            await db.SaveChangesAsync();
            return Ok(new { Message = "Assets uploaded ok", Assets = assets });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException().Message);
        }
    }
