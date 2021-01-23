      public static void SaveImage(Image image, string savedName, int width = 0, int height = 0)
        {
            Image originalImage = image;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + savedName;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
    .
    .
    . The Rest code
    .
    .
    .
    .
    .
    .
    .
    }
