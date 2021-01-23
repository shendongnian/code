    private void videoMaker( string outputFileName , string[] inputImageSequence)
    {
      int width = 1920;
      int height = 1080;
      var framRate = 25;
    
      using (var vFWriter = new VideoFileWriter())
      {
        // create new video file
        vFWriter.Open(outputFileName, width, height, framRate, VideoCodec.Raw);
    
        foreach (var imageLocation in inputImageSequence)
        {
          Bitmap imageFrame = System.Drawing.Image.FromFile(imageLocation) as Bitmap;
          vFWriter.WriteVideoFrame(imageFrame);
        }
        vFWriter.Close();
      }
    }
