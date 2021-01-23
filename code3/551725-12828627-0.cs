    public enum ImageType
    {
        Jpg,
        Gif,
        Png
    }
    
    public static ImageType ParseImagetype(string typeName)
    {
        typeName = typeName.ToLower();
        switch (typeName)
        {
            case "Gif":
                return ImageType.Gif;
            case "png":
                return ImageType.Png;
            default:
            case "jpg":
                return ImageType.Jpg;
        }
    }...
