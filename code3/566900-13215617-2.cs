    public static class IconUrls {
        static Dictionary<string, string> _extensions;
        static string DefaultUrl = "~/siteroot/images/icons/genericicon.png";
        
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
            if(string.IsNullOrEmpty(extension) || !_dictionary.ContainsKey(extension.Trim().ToUpper()))
                return DefaultUrl;
            return _extensions[extension.Trim().ToUpper()];
        }
    }
