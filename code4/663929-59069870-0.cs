    using (Bitmap bmp = new Bitmap(webStream))
    {
         using (Bitmap newImage = new Bitmap(bmp))
         {
             newImage.Save("c:\temp\test.jpg", ImageFormat.Jpeg);
         }
    }
