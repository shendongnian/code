    public void ProcessFrames(){
        while (true)
        {
            dataSemaphore.WaitOne();
            if (nFrameCount>0)
            {
                MemoryStream ms = new MemoryStream(previewBuffer1);
    
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    BitmapImage biImg = new BitmapImage();
                    biImg.SetSource(ms);
    
                    ImageSource imgSrc = biImg as ImageSource;
                    capturedFrame.Source = imgSrc;
                });
            }
        }
    }
