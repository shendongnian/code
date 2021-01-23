        DispatcherTimer UpdateTimer; 
        public Capture capWebCam = null;
        public bool binCapturingInProgress = false;
        public Image<Bgr, byte> imgOriginal;
        public Image<Gray, byte> imgProcessed;
        public ImageBox imageBox1 = new ImageBox();
        public TextBox textBox1;
        public List<PointF> centerList;
        CircleF[] circles;
        public void newCapture(bool b, List<PointF> centers)
        {
            centerList = centers;
            binCapturingInProgress = b;
            try
            {
                capWebCam = new Capture();
            }
            catch (NullReferenceException except)
            {
                MessageBox.Show(except.Message);
                return;
            }
            binCapturingInProgress = true;
            //Start the timer after the device is ready to be captured (this looks like a good place to do it)
            UpdateTimer = new DispatcherTimer(DispatcherPriority.Render);
            UpdateTimer.Interval = TimeSpan.FromMilliseconds(1000 / 60);
            UpdateTimer.Tick += processFrameAndUpdateGUI;
            UpdateTimer.Start();
        }
        private void processFrameAndUpdateGUI(object o, EventArgs e)
        {
           //Capture new image, render it and display it.
            imgOriginal = capWebCam.QueryFrame();
            if (imgOriginal == null) 
            {
                return;
            }
            imgProcessed = imgOriginal.InRange(new Bgr(0, 0, 150)/*min filter*/, new Bgr(80, 80, 256));
         //   imgProcessed = imgOriginal.InRange(new Bgr(0, 0, 175)/*min filter*/, new Bgr(100, 100, 256));
            imgProcessed = imgProcessed.SmoothGaussian(9);//9
            circles = imgProcessed.HoughCircles(new Gray(100), //canny threshhold
                                                          new Gray(50), //accumolator threshold
                                                          2,//size of image 
                                                          imgProcessed.Height / 4, //min size in pixels between centers of detected circles
                                                          15, //min radios
                                                          43)[0];//max radios and get circles from first channel
            foreach (CircleF circle in circles)
            {
                centerList.Add(circle.Center);
                //     circlesOfBalls.Add(circle);
                if (textBox1.Text != "") textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("ball position = x" + centerList[centerList.Count - 1].X +
                                    ", y = " + centerList[centerList.Count - 1].Y.ToString().PadLeft(4)
                                    + "centerList.Count= " + centerList.Count);
                // + ", radios = " + centerList[centerList.Count - 1].Radius.ToString("###,000").PadLeft(7))
                textBox1.ScrollToCaret();// scrolls the textBox to last line
                // draw a small green circle in the center
                CvInvoke.cvCircle(imgOriginal, // draw on the original image
                                  new Point((int)circle.Center.X, (int)circle.Center.Y),//center point of circle
                                  3, // radios of circle,
                                  new MCvScalar (0, 255, 0), // draw in green color
                                  -1, //indicates to fill the circle
                                  LINE_TYPE.CV_AA, //smoothes the pixels
                                  0);// no shift 
                //draw a red circle around the detected object
              //  if (imgOriginal.Data != null) 
                    imgOriginal.Draw(circle,    //current circle
                                new Bgr(Color.Red), // draw pure red
                                3);
            } // end of for each
           // if(imgOriginal.Data != null)
                imageBox1.Image = imgOriginal;
        }
 
