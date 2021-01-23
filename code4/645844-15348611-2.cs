    // Assumes 1:1
    public static class ImageFactory
    {
        static Dictionary<Image, myObject> images
            = new Dictionary<Image, myObject>();
        // The factory handles creation and tracking
        public static Image Create(myObject obj)
        {
            Image image = obj.getImage();
            images[image] = obj;
            return image;
        }
        // Which now lets you figure out the "owner" of the image
        public static myObject FindOwner(Image image)
        {
            return images.ContainsKey(image) ? images[image] : null;
        }
    }
