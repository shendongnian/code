    using (MagickImageCollection images = new MagickImageCollection())
    {
      MagickImage firstFrame = new MagickImage("first.gif");
      firstFrame.AnimationDelay = 1500;
      images.Add(firstFrame);
      
      MagickImage secondFrame = new MagickImage("second.gif");
      secondFrame.AnimationDelay = 200;
      images.Add(secondFrame);
      
      // This method will try to make your output image smaller.
      images.OptimizePlus();
      
      images.Write(@"c:\ddd.gif");
    }
