    using System;
    
    public class ImageConverter
    {
        public void button1_Click(Object sender, RoutedEventArgs e)
        {
          string filename = "c:\myfile.bmp";
          SendImageToPlayer send = new SendImageToPlayer();
          send.Filename = filename;
          Thread t = new Thread(send.ReadImageFile);
    }
