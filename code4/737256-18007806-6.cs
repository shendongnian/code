    private static string CombineFramesIntoGif(int startFrameCount, int endFrameCount)
    {
        List<string> imageFilePaths = new List<string>();
        for (int i = startFrameCount; i < endFrameCount; i++)
        {
            imageFilePaths.Add(tempFolder + i.ToString() + ".png");
        }
                
        string outputFilePath = tempFolder + "test.gif";
        AnimatedGifEncoder e = new AnimatedGifEncoder();
        e.Start(outputFilePath);
        e.SetDelay(500);
        //-1:no repeat,0:always repeat
        e.SetRepeat(0);
        for (int i = 0; i < imageFilePaths.Count; i++)
        {
            e.AddFrame(Image.FromFile(imageFilePaths[i]));
        }
        e.Finish();
        return outputFilePath;
    }
