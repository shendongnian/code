    **For this you should install these packages
    Install-Package AForge
    Install-Package AForge.Video
    Install-Package AForge.Video.DirectShow
    Install-Package ZXing.Net
    
    you can watch this video for more help
    https://www.youtube.com/watch?v=wcoy0Gwxr50**
    
    
    
    
        using System.IO;
        using AForge;
        using AForge.Video;
        using AForge.Video.DirectShow;
        using ZXing;
        using ZXing.Aztec;
    
    
          private void Form1_Load(object sender, EventArgs e)
                {
                    CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    foreach (FilterInfo Device in CaptureDevice)
                    {
                        comboBox1.Items.Add(Device.Name);
                    }
    
                    comboBox1.SelectedIndex = 0;
                    FinalFrame = new VideoCaptureDevice();
                }
    
                private void button1_Click(object sender, EventArgs e)
                {
                    FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
                    FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                    FinalFrame.Start();
    
                }
    
                private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
                {
                    pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                }
    
                private void timer1_Tick(object sender, EventArgs e)
                {
                    BarcodeReader Reader = new BarcodeReader();
                    Result result = Reader.Decode((Bitmap)pictureBox1.Image);
                    try
                    {
                        string decoded = result.ToString().Trim();
                        if (decoded != "")
                        {
                            timer1.Stop();
                            MessageBox.Show(decoded);
                            Form2 form = new Form2();
                            form.Show();
                            this.Hide();
    
                        }
                    }
                    catch(Exception ex){
    
                    }
                }
    
                private void button2_Click(object sender, EventArgs e)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
    
                private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {
                    if (FinalFrame.IsRunning == true)
                    {
                        FinalFrame.Stop();
                    }
                }
