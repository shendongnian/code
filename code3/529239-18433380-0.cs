    using Microsoft.Kinect;
    using System.Windows.Media; // WindowsBase
    using System.Windows.Media.Imaging; //PresentationCore
...
    static void sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
                                   
            DepthImageFrame DIF = e.OpenDepthImageFrame();
            if (DIF == null){return;}            
            
            short[] pixels = new short[DIF.PixelDataLength];
            DIF.CopyPixelDataTo(pixels);
            if (check == 0)
            {
                int stride = DIF.Width * DIF.BytesPerPixel;
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(BitmapSource.Create(
                    DIF.Width, DIF.Height, 96, 96, PixelFormats.Gray16, null, pixels, stride)));
                
                string path = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "kimage.png");
                
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        encoder.Save(fs);
                    }
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.ToString());
                }
                check = 1;
            }}
