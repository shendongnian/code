    // Assumes 1:1
    public static class ImageFactory
    {
        static Dictionary<Image, myObject> images
            = new Dictionary<Image, myObject>();
        public static Image Create(myObject obj)
        {
            Image image = obj.getImage();
            images[image] = obj;
            return image;
        }
        public static myObject FindOwner(Image image)
        {
            return images.ContainsKey(image) ? images[image] : null;
        }
    }
