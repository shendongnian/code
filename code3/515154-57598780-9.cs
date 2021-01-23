    public static void MergeImage(string src, string dest, MergeType type = MergeType.MultiplePage)
    {
        var files = new DirectoryInfo(src).GetFiles();
    
        using (var images = new MagickImageCollection())
        {
            foreach (var file in files)
            {
                var image = new MagickImage(file)
                {
                    Format = MagickFormat.Tif,
                    Depth = 8,
                };
                images.Add(image);
            }
    
            switch (type)
            {
                case MergeType.Vertical:
                    using (var result = images.AppendVertically())
                    {
                        result.AdaptiveResize(new MagickGeometry(){Height = 600, Width = 800});
                        result.Write(dest);
                    }
                    break;
                case MergeType.Horizontal:
                    using (var result = images.AppendHorizontally())
                    {
                        result.AdaptiveResize(new MagickGeometry(){Height = 600, Width = 800});
                        result.Write(dest);
                    }
                    break;
                case MergeType.Montage:
                    var settings = new MontageSettings
                    {
                        BackgroundColor = new MagickColor("#FFF"),
                        Geometry = new MagickGeometry("1x1<")
                    };
    
                    using (var result = images.Montage(settings))
                    {
                        result.Write(dest);
                    }
                    break;
                case MergeType.MultiplePage:
                    images.Write(dest);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Un-support choice");
            }
    
            images.Dispose();
        }
    }
    
    public enum MergeType
    {
        MultiplePage,
        Vertical,
        Horizontal,
        Montage
    }
