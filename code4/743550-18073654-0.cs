    public static class UIViewExtensions {
        public static UIImage AsImage(this UIView view) {
            UIGraphics.BeginImageContextWithOptions(view.Bounds.Size, view.Opaque, 0);
            view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;
        }
        public static UIImage TakeScreenshot() {
            return UIApplication.SharedApplication.KeyWindow.AsImage();
        }
    }
