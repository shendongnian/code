    Private void Form1_load(object sender, EventArgs e)
    {
    	try
    	{
    		//capture webcam
    		Capture grabber = new Capture();
    		//test capture frame
    		grabber.QueryFrame();
    		//trigger event when application is idle
    		Application.Idle += new EventHandler(FrameGrabber);
    	}
    	catch
    	{
    		MessageBox.Show("Capture fail to start");
    	}
    }
            
    void FrameGrabber(object sender, EventArgs e)
    {
    	Image<Bgr,byte> ImageFrame = grabber.QueryFrame().Resize(320,240,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
    	Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
    	MCvAvgComp[] faces =  grayframe.DetectHaarCascade(haar, 1.4, 4,
    									HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
    									new Size(25, 25))[0];
    	foreach (MCvAvgComp face in faces)
    	{
    		ImageFrame.Draw(face.rect, new Bgr(Color.Green), 3);
    	}
    	CamImageBox.Image = ImageFrame;
    }
