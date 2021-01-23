    private Bitmap[] GetResourceImages()
    {
        PropertyInfo[] props = typeof(ImageResource).GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
        var images = props.Where(prop => prop.PropertyType == typeof(Bitmap)).Select(prop => prop.GetValue(null, null) as Bitmap).ToArray();
    
        return images;
    }
