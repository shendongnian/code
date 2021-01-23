    private static readonly string tempFolder = @"C:\temp\";
               
    static void Main(string[] args)
    {
        CombineGifs(@"c:\temp\a.gif", @"c:\temp\b.gif");
    }
    
    public static void CombineGifs(string firstImageFilePath, string secondImageFilePath)
    {
        int frameCounter = ExtractGifFramesAndGetCount(firstImageFilePath, 0);
        int secondframeCounter = ExtractGifFramesAndGetCount(secondImageFilePath, frameCounter);
    
        string filePathOfCombinedGif = CombineFramesIntoGif(0, secondframeCounter);
    }
    
    private static int ExtractGifFramesAndGetCount(string filePath, int imageNameStartNumber)
    {
        ////NGif had an error when I tried it
        //GifDecoder gifDecoder = new GifDecoder();
        //gifDecoder.Read(filePath);
    
        //int frameCounter = imageNameStartNumber + gifDecoder.GetFrameCount();
        //for (int i = imageNameStartNumber; i < frameCounter; i++)
        //{
        //    Image frame = gifDecoder.GetFrame(i);  // frame i
        //    frame.Save(tempFolder + i.ToString() + ".png", ImageFormat.Png);
        //}
    
        //So we'll use the Gifimage implementation
        GifImage gifImage = new GifImage(filePath);
        gifImage.ReverseAtEnd = false;
        int frameCounter = imageNameStartNumber + gifImage.GetFrameCount();
        for (int i = imageNameStartNumber; i < frameCounter; i++)
        {
            Image img = gifImage.GetNextFrame();
            img.Save(tempFolder + i.ToString() + ".png");
        }
        return frameCounter;
    }
