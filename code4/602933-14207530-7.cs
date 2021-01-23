         Capture capture = new Capture();
        
         ImageViewer viewer = new ImageViewer();
         BlobTrackerAutoParam param = new BlobTrackerAutoParam();
         param.ForgroundDetector = new ForgroundDetector(Emgu.CV.CvEnum.FORGROUND_DETECTOR_TYPE.FGD);
         param.FGTrainFrames = 10;
         BlobTrackerAuto tracker = new BlobTrackerAuto(param);
         int frames = 0;
         Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
         {
            frames++;//Add to number of frames
            if (frames == 10)
            {
            frames = 0;//if it is after 10 frames, do processing and reset frames to 0
            tracker.Process(capture.QuerySmallFrame().PyrUp());
            Image<Gray, Byte> img = tracker.GetForgroundMask();
            //viewer.Image = tracker.GetForgroundMask();
            int blobs = 0;
            MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 1.0, 1.0);
            foreach (MCvBlob blob in tracker)
            {
               //img.Draw(Rectangle.Round(blob), new Gray(255.0), 2);
               //img.Draw(blob.ID.ToString(), ref font, Point.Round(blob.Center), new Gray(255.0));
               //Only uncomment these if you want to draw a rectangle around the blob and add text
               blobs++;//count each blob
            }
            blobs = /*your counter here*/;
            blobs = 0; //reset 
            viewer.Image = img;//get next frame
         });
         viewer.ShowDialog();
