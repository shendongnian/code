    public static class IconUrls {
        static Dictionary<string, string> _extensions;
        
        static IconUrls {
            extensions = new Dictionary<string, string>() {
                { "JPG", "~/siteroot/images/icons/jpegicon.png" }, 
                { "JPEG", "~/siteroot/images/icons/jpegicon.png" }
            }
        }
        
        public static Dictionary<string, string> Extensions {
            get {
                return _extensions;
            }
        }
        public static string GetIconUrl(string extension) {
        {
            return _extensions[extension.ToUpper()];
        }
    }
