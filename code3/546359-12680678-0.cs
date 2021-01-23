    static String[] SplitFile(String file_name)
    {
        System.Drawing.Image imageFile = System.Drawing.Image.FromFile(file_name);
        System.Drawing.Imaging.FrameDimension frameDimensions = new System.Drawing.Imaging.FrameDimension(imageFile.FrameDimensionsList[0]);
        int NumberOfFrames = imageFile.GetFrameCount(frameDimensions);
        string[] paths = new string[NumberOfFrames];
        for (int intFrame = 0; intFrame < NumberOfFrames; ++intFrame)
        {
            imageFile.SelectActiveFrame(frameDimensions, intFrame);
            Bitmap bmp = new Bitmap(imageFile);
            paths[intFrame] = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + intFrame.ToString() + ".tif";
            bmp.Save(paths[intFrame], System.Drawing.Imaging.ImageFormat.Tiff);
            bmp.Dispose();
        }
        imageFile.Dispose();
        return paths;
    }
