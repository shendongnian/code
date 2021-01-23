        public void ResizeImage(Device objDevice)
        {
            string OriginalFile, NewFile;
            OriginalFile = HttpContext.Current.Server.MapPath("DeviceLogo") + @"\" + objDevice.FileName;
            NewFile = OriginalFile;
            System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);
            System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(objDevice.LogoWidth, objDevice.LogoHeight, null, IntPtr.Zero);
            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();
            // Save resized picture
            NewImage.Save(NewFile);
        }
