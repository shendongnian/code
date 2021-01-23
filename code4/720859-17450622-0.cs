    private static Image GetImage(string path)
    {
        Image image;
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            image = Image.FromStream(fs);
        }
        return image;
    }
