    public static void Main()
    {
        var files = new DirectoryInfo(@"C:\temp\Images").GetFiles();
    
        using (var images = new MagickImageCollection())
        {
            foreach (var file in files)
            {
                var image = new MagickImage(file)
                {
                    Format = MagickFormat.Tif,
                    Depth = 8
                };
                images.Add(image);
            }
    
            using (var result = images.AppendHorizontally())
            {
                result.Write(@"C:\Temp\Output\Merged.tiff");
            }
            images.Dispose();
        }
    }
