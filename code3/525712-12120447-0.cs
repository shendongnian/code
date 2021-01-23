    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }
    
            if (file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }
    
            try
            {
                var allowedFormats = new[] 
                { 
                    ImageFormat.Jpeg, 
                    ImageFormat.Png, 
                    ImageFormat.Gif, 
                    ImageFormat.Bmp 
                };
                using (var img = Image.FromStream(file.InputStream))
                {
                    return allowedFormats.Contains(img.RawFormat);
                }
            }
            catch { }
            return false;
        }
    }
