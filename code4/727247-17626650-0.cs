    public static void Main()
    {    
        float motionLevel = 0F;
        System.Drawing.Bitmap bitmap = null;
        AForge.Video.FFMPEG.VideoFileReader reader = null;
        AForge.Vision.Motion.MotionDetector motionDetector = null;    
        motionDetector = GetDefaultMotionDetector();
        reader.Open(@"C:\Temp.wmv");
    
        while (true)
        {
            bitmap = reader.ReadVideoFrame();
            if (bitmap == null) break;
            // motionLevel will indicate the amount of motion as a percentage.
            motionLevel = motionDetector.ProcessFrame(bitmap);
            // You can also access the detected motion blobs as follows:
            // ((AForge.Vision.Motion.BlobCountingObjectsProcessing) motionDetector.Processor).ObjectRectangles [i]...
        }
        reader.Close();
    }
    // Play around with this function to tweak results.
    public static AForge.Vision.Motion.MotionDetector GetDefaultMotionDetector ()
    {
    	AForge.Vision.Motion.IMotionDetector detector = null;
    	AForge.Vision.Motion.IMotionProcessing processor = null;
    	AForge.Vision.Motion.MotionDetector motionDetector = null;
    
    	//detector = new AForge.Vision.Motion.TwoFramesDifferenceDetector()
    	//{
    	//	DifferenceThreshold = 15,
    	//	SuppressNoise = true
    	//};
    
    	//detector = new AForge.Vision.Motion.CustomFrameDifferenceDetector()
    	//{
    	//	DifferenceThreshold = 15,
    	//	KeepObjectsEdges = true,
    	//	SuppressNoise = true
    	//};
    
    	detector = new AForge.Vision.Motion.SimpleBackgroundModelingDetector()
    	{
    		DifferenceThreshold = 10,
    		FramesPerBackgroundUpdate = 10,
    		KeepObjectsEdges = true,
    		MillisecondsPerBackgroundUpdate = 0,
    		SuppressNoise = true
    	};
    
    	//processor = new AForge.Vision.Motion.GridMotionAreaProcessing()
    	//{
    	//	HighlightColor = System.Drawing.Color.Red,
    	//	HighlightMotionGrid = true,
    	//	GridWidth = 100,
    	//	GridHeight = 100,
    	//	MotionAmountToHighlight = 100F
    	//};
    
    	processor = new AForge.Vision.Motion.BlobCountingObjectsProcessing()
    	{
    		HighlightColor = System.Drawing.Color.Red,
    		HighlightMotionRegions = true,
    		MinObjectsHeight = 10,
    		MinObjectsWidth = 10
    	};
    
    	motionDetector = new AForge.Vision.Motion.MotionDetector(detector, processor);
    
    	return (motionDetector);
    }
