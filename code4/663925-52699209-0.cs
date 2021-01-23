    private Bitmap getImage(byte[] imageBinaryData){
        .
        .
        .
        Bitmap image;
        using (var stream = new MemoryStream(imageBinaryData))
        {
            image = new Bitmap(stream);
        }
        return image;
    }
