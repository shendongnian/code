    public async Task<IHttpActionResult> GetRenderImage(long id, int size = 0)
        {
            // Load template           
            var file = HttpContext.Current.Server.MapPath("~/Content/media/template.png"); 
            WebImage img = new WebImage(file);
            
            // some operations with image, for sample scale or crop
            ...
                      
            // get image data
            var bytes = img.GetBytes("image/jpeg");
            
            // Save to blob
            var p = getCloudBlobContainer("RenderImg");
            CloudBlockBlob blob = p.GetBlockBlobReference(String.Format("{0}.jpg", id);
            blob.Properties.ContentType = "image/jpeg";
            await blob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
            var url = blob.Uri.ToString();
            // Redirect to Azure blob image
            return Redirect(url);
        }
