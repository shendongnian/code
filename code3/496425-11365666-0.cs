      Image<Bgr, Byte> img; 
        private Capture capture;
        private bool captureInProgress;
        private void gumb_kamera_Click(object sender, EventArgs e)
        {
           
        }
        private void processFunction(object sender, EventArgs e)
        {
             img = capture.QueryFrame();
           //  imageBox1.Image = img;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture(0);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if (capture != null)
            {
                if (captureInProgress)
                {
                    Application.Idle -= processFunction;
                }
                else
                {
                    Application.Idle += processFunction;
                }
                captureInProgress = !captureInProgress;
            }
            
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
     
        imageBox1.Image = img; 
           
        }
