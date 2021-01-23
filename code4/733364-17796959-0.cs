    public class ImageCache {
        private Dictionary<string, UIImage> cache = new Dictionary<string, UIImage>();
        public static readonly ImageCache SharedInstance = new ImageCache();
        public ImageCache() {
        }
        private UIImage ImageForUrl(string url) {
            UIImage image = null;
            if (!this.cache.TryGetValue(url, out image)) {
                NSUrl url = new NSUrl(url);
                NSData data = NSData.FromUrl(url);
                image = UIImage.FromData(data);
                if (image != null) {
                    this.cache[url] = image;
                }
            }
            return image;
        }
        public UIImage this[string url] {
            get { return this.ImageForUrl(url); }
        }
    }
