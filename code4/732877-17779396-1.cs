    public Bitmap getResourceBitmapWithName(string image_name) {
        foreach (DictionaryEntry kvp in Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true)) {
            if ((string)kvp.Key == image_name) {
                var bmp = kvp.Value as Bitmap;
                if (bmp != null) {
                    return bmp;
                }
            }
        }
    
        return null;
    }
