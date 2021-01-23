        [WebMethod]
        public void UploadFile()
         {
             if (HttpContext.Current.Request.Files.AllKeys.Any())
             {
                 // Get the uploaded image from the Files collection
                 var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                 if (httpPostedFile != null)
                 {
                     ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
                     imgCompress.GetImage = new System.Drawing.Bitmap(httpPostedFile.InputStream);
                     imgCompress.Height = 260;
                     imgCompress.Width = 358;
                     //imgCompress.Save(httpPostedFile.FileName, @"C:\Documents and Settings\Rasmi\My Documents\Visual Studio2008\WebSites\compressImageFile\Logo");
                     imgCompress.Save(httpPostedFile.FileName, HttpContext.Current.Server.MapPath("~/Download/"));
 
                 }
             }
         }
