           string fileContent = null;
            /* Check the file actually has some content to display to the user */
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                byte[] fileBytes = new byte[uploadFile.ContentLength];
                int byteCount = uploadFile.InputStream.Read(fileBytes, 0, (int)uploadFile.ContentLength);
                if (byteCount > 0)
                {
                    fileContent = CreateBase64Image(fileBytes);
                }
            }
        private string CreateBase64Image(byte[] fileBytes)
        {
            Image streamImage;
            /* Ensure we've streamed the document out correctly before we commit to the conversion */
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                /* Create a new image, saved as a scaled version of the original */
                streamImage = ScaleImage(Image.FromStream(ms));
            }
            using (MemoryStream ms = new MemoryStream())
            {
                /* Convert this image back to a base64 string */
                streamImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
