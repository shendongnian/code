        // replace with an entry loaded from a config file    
        const string ImageRoot = @"D:\ShopMonkey_Web_21-6-12\ShopMonkey"; 
        // replace this is your user instance
        object user = new object(); 
        string Imagename = objUser.UserID + filename;
        string uploadImagePath = Path.Combine(ImageRoot, "Images", Imagename);
        string thumbnailPath = Path.Combine(ImageRoot, "ThumbNails", Imagename);
        objUser.UploadImagePath = uploadImagePath;
        objUser.UploadImagename = Imagename;
        objUser.UploadThumbnailPath = thumbnailPath;
        // delete both if they exist
        if (File.Exists(uploadImagePath))
            File.Delete(uploadImagePath);
        if (File.Exists(thumbnailPath))
              File.Delete(thumbnailPath);
        // replace this with your uploaded file details
        object fileInfo = new object(); 
        using (System.Drawing.Image img1 = System.Drawing.Image.FromFile(uploadImagePath)) {
              img1.Save(uploadImagePath);
              using (System.Drawing.Image bmp1 = img1.GetThumbnailImage(50, 50, null, IntPtr.Zero)) {
                bmp1.Save(thumbnailPath);
              }
              FileUpload.SaveAs(uploadImagePath);
        }
