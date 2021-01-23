    // Assumes 1:1, slower than the prior approach
    static Dictionary<myObject, WeakReference> images
        = new Dictionary<myObject, WeakReference>();
    public static Image Create(myObject obj)
    {
        Image image = obj.getImage();
        images[obj] = new WeakReference(image);
        return image;
    }
    public static myObject FindOwner(Image image)
    {
        return images.Where(xx => xx.Value.IsAlive
                               && xx.Value.Target == image)
                     .FirstOrDefault();
    }
