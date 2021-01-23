       public partial class PictureBoxVideo : Form
       {
          public PictureBoxVideo()
          {
             InitializeComponent();
             var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
             var videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
             videoSource.NewFrame += Handle_Very_New_Frame;
             videoSource.Start();
          }
    
          private void Handle_Very_New_Frame(object sender, NewFrameEventArgs eventArgs)
          {
             this.Invoke((MethodInvoker)delegate {
                pictureBox.Image = new Bitmap(eventArgs.Frame);
             });
          }
       }
