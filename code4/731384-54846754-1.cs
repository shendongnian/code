        private bool IsImage(string fileExtension)
        {
            return GetImageFileExtensions().Contains(fileExtension.ToLower()));
        }
        private static List<string> GetImageFileExtensions()
        {
            return ImageCodecInfo.GetImageEncoders()
                                 .Select(c => c.FilenameExtension)
                                 .SelectMany(e => e.Split(';'))
                                 .Select(e => e.Replace("*", "").ToLower())
                                 .ToList();            
        }
