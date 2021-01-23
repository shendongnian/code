    void timer_Tick(object sender, EventArgs e)
    {
        Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(
                    delegate {
        using (  Image<Bgr, byte> Frame = capture.QueryFrame())
        {
            if (Frame != null)
            {
                bs1 = ToBitmapSource(Frame);
                webcam.Source = ToBitmapSource(Frame); // ToBitmapSource convert image to bitmapsource
                Frame.Save("fg.jpeg");   //this work but use lot of processing 
            }
        }}));
    }
