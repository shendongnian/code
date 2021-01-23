    using System.Threading;
    bool photo_was_taken = false;
    
    private void buttonStartCamera_Click(object sender, EventArgs e) 
     {
 
    Thread thread = new Thread(new ThreadStart(exitcamera));
    thread.Start(); 
     FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
     FinalVideo.DesiredFrameSize = new System.Drawing.Size(640, 480);
     FinalVideo.DesiredFrameRate = 90;
     FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
     FinalVideo.ProvideSnapshots = true;  //snapshots
     FinalVideo.Start(); 
     }
    private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // what you want to do ( your code is here )
            photo_was_taken = true; 
            
        }
     private void exitcamera()
     { 
            while (!photo_was_taken)
            {
                Thread.Sleep(5); // you can change wait milliseconds
            }
            FinalVideo.SignalToStop();
            FinalVideo.NewFrame -= new NewFrameEventHandler(FinalVideo_NewFrame);
            //FinalVideo.WaitForStop();
            while (FinalVideo.IsRunning)
            {
                FinalVideo.Stop();
                // FinalVideo = null; >> // that is not condition
            }
     }
