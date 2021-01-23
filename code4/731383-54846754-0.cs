        private bool isImage(string fileExtension)
        {
            if (getImageFileExtensions().Contains(fileExtension.ToLower()))
                return true;
            else
                return false;
        }
        private static List<string> getImageFileExtensions()
        {
            var imageFileExtensions = ImageCodecInfo.GetImageEncoders()
                                      .Select(c => c.FilenameExtension)
                                      .SelectMany(e => e.Split(';'))
                                      .Select(e => e.Replace("*", "").ToLower())
                                      .ToList();
            return imageFileExtensions;
        }
