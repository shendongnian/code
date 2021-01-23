    public Bitmap GetImage(HttpContext context, out bool cacheAvailable)
    {
        // Get location
        Bitmap bitOutput = null;
        cacheAvailable = false;
        try
        {
            if (!String.IsNullOrEmpty(location))
            {
                Image image = Image.FromFile(appPath + location);
                bitOutput = new Bitmap(image);
                hasSetSize = SetHeightWidth(context, bitOutput);
                if (!System.IO.Directory.Exists(cacheLocation))
                {
                    System.IO.Directory.CreateDirectory(cacheLocation);
                }
                // Generate cache key
                cacheKey = "imagehandler_" + _width + "x" + _height + "_" + context.Request["RotateFlip"] + context.Request["type"];
                if (File.Exists(cacheLocation + cacheKey + ".png"))
                {
                    image = Image.FromFile(cacheLocation + cacheKey + ".png");
                    bitOutput = new Bitmap(image);
                    cacheAvailable = true;
                }
            }
            else
            {
                throw new Exception("Can't load original or save to cache, check directory permissions!");
            }
        }
        catch (Exception)
        {
            Image image = Image.FromFile(appPath + noImageUrl);
            bitOutput = new Bitmap(image);
        }
        return bitOutput;
    }
 
