    public static Image CreateImage(string filePath)
    {
            var bytes = File.ReadAllBytes(filePath);
            var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
    }
