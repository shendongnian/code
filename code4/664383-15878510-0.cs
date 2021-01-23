    string input = Request.Url.AbsoluteUri;
            string output = input.Substring(input.IndexOf('=') + 1);
            string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            
            Stream stream = FileUpload2.PostedFile.InputStream;
    
            Bitmap sourceImage = new Bitmap(stream);
    
            int maxImageWidth = 800;
    
            if (sourceImage.Width > maxImageWidth)
            {
                int newImageHeight = (int)(sourceImage.Height * ((float)maxImageWidth / (float)sourceImage.Width));
                Bitmap resizedImage = new Bitmap(maxImageWidth, newImageHeight);
                Graphics gr = Graphics.FromImage(resizedImage);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(sourceImage, 0, 0, maxImageWidth, newImageHeight);
                // Save the resized image:
                resizedImage.Save(Server.MapPath("~/Uploads/" + output + "/") + fileName);
            }
