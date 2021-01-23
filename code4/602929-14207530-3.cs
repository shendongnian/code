         Capture capture = new Capture();
        
         ImageViewer viewer = new ImageViewer();
         BlobTrackerAutoParam param = new BlobTrackerAutoParam();
         param.ForgroundDetector = new ForgroundDetector(Emgu.CV.CvEnum.FORGROUND_DETECTOR_TYPE.FGD);
         param.FGTrainFrames = 10;
         BlobTrackerAuto tracker = new BlobTrackerAuto(param);
         Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
         {
            tracker.Process(capture.QuerySmallFrame().PyrUp());
            Image<Gray, Byte> img = tracker.GetForgroundMask();
            //viewer.Image = tracker.GetForgroundMask();
            MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 1.0, 1.0);
            foreach (MCvBlob blob in tracker)
            {
               img.Draw(Rectangle.Round(blob), new Gray(255.0), 2);
               img.Draw(blob.ID.ToString(), ref font, Point.Round(blob.Center), new Gray(255.0));
            }
            viewer.Image = img;
         });
         viewer.ShowDialog();
