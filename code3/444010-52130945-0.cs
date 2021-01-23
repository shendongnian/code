        public VideoCapture capture;
        private void btnCatpure_Click(object sender, EventArgs e)
        {
            // each click a single frame will be capture and then display in the control.
            Mat iframe = new Mat();
            capture.Retrieve(iframe, 0);
            Mat grayFrame = new Mat();
            CvInvoke.CvtColor(iframe, grayFrame, ColorConversion.Bgr2Gray);
            pictureBox1.Image =  iframe.Bitmap;
            pictureBox1.Image = grayFrame.Bitmap;
        }
