    public class ImageFactory
    {
        private readonly HttpContext _context;
        private Image _image;
        public ImageFactory(HttpContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get image by name from post
        /// </summary>
        /// <param name="ctxImageParamName">image that have been posted in email</param>
        /// <returns></returns>
        public string SaveImage(string ctxImageParamName)
        {
            if (string.IsNullOrEmpty(_context.Request[ctxImageParamName])) return null;
            string url = GenerateImagePath("FrameMe");
            ByteArrayToImageAndSave(Decode(_context.Request[ctxImageParamName]), url);
            return url;
        }
        public bool DeleteImage(string url)
        {
            try
            {
                if (!File.Exists(url)) return false;
                File.Delete(url);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }    
        }
        private string GenerateImagePath(string directory)
        {
            return _context.Server.MapPath(string.Format("~/Images/{1}/Image1_{0}.jpg", DateTime.Now.ToString("ddMMyyyyHHmmss"), directory));
        }
        private void ByteArrayToImageAndSave(byte[] byteArrayIn, string imageUrl)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                _image = Image.FromStream(ms);
                _image.Save(imageUrl, new ImageFormat(Guid.NewGuid()));
                _image.Dispose();
            }
            catch (Exception ex)
            {
                _image = null;
            }
        }
        private byte[] Decode(string str)
        {
            return Convert.FromBase64String(str);
        }
    }
