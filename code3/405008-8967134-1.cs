    [HttpPost]
    public ActionResult ImageUpload(HttpPostedFileBase fileBase, PhotoViewModel photoViewModel)
    {
        if (photoViewModel.Button == "Upload")
        {
            photoViewModel.ImageValid = "Valid";
            ImageService imageService = new ImageService();
    
            if (fileBase != null && fileBase.ContentLength > 0 && fileBase.ContentLength <= 2097152 && fileBase.ContentType.Contains("image/"))
            {
                Path.GetExtension(fileBase.ContentType);
                var extension = Path.GetExtension(fileBase.FileName);
    
                if (extension.ToLower() != ".jpg" && extension.ToLower() != ".gif") // only allow these types
                {
                    photoViewModel.ImageValid = "Not Valid";
                    ModelState.AddModelError("Photo", "Wrong Image Type");
                    return View(photoViewModel);
                }
                EncoderParameters encodingParameters = new EncoderParameters(1);
                encodingParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L); // Set the JPG Quality percentage
    
                ImageCodecInfo jpgEncoder = imageService.GetEncoderInfo("image/jpeg");
                var uploadedimage = Image.FromStream(fileBase.InputStream, true, true);
    
                Bitmap originalImage = new Bitmap(uploadedimage);
                Bitmap newImage = new Bitmap(originalImage, 274, 354);
    
                Graphics g = Graphics.FromImage(newImage);
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
    			// change from originalImage to newImage
                g.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
    
                var streamLarge = new MemoryStream();
                newImage.Save(streamLarge, jpgEncoder, encodingParameters);
    
                var fileExtension = Path.GetExtension(extension);
                string newname;
                if (photoViewModel.photoURL != null)
                {
                    newname = photoViewModel.photoURL;
                }
                else
                {
                    newname = Guid.NewGuid() + fileExtension;
                }
    
                //changed this up now, so it stores the image in db as apposed to physical path
                photoViewModel.photo = newname;
                photoViewModel.ContentType = fileBase.ContentType;
    			// using the memoryStream streamLarge
                // old code: Int32 length = fileBase.ContentLength;			
                byte[] tempImage = new byte[streamLarge.Length];
    			// replace fileBase.InputStream with streamLarge
                streamLarge.Read(tempImage, 0, length);
                photoViewModel.ImageData = tempImage;          
    
                TempImageUpload tempImageUpload = new TempImageUpload();
                tempImageUpload.TempImageData = tempImage;
                tempImageUpload.ContentType = photoViewModel.ContentType;
    
                photoViewModel.TempImageId = _service.InsertImageDataBlob(tempImageUpload);
    
                originalImage.Dispose();
                streamLarge.Dispose();
                return View(photoViewModel);
            }
    
            if (fileBase != null)
            {
                if (fileBase.ContentLength > 0) ModelState.AddModelError("Photo", "Image size too small");
                if (fileBase.ContentLength <= 2097152) ModelState.AddModelError("Photo", "Image size too big");
                if (fileBase.ContentType.Contains("image/")) ModelState.AddModelError("Photo", "Wrong Image Type");
            }
            else ModelState.AddModelError("Photo", "Please upload a image");
    
            if (!ModelState.IsValid)
            {
                photoViewModel.ImageValid = "Not Valid";
                return View(photoViewModel);
            }
        }
        return View(photoViewModel);
    }
