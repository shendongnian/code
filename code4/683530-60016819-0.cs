            using System.Drawing;
            using System.Drawing.Imaging;
            using Emgu.CV;
            using Emgu.CV.Structure;
            //inputImage type is System.Drawing.Image
            int stride = 0;
            Bitmap bitmapImage = new Bitmap(inputImage);
            Rectangle rectangle = new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height);//System.Drawing
            BitmapData bmpData = bitmapImage.LockBits(rectangle, ImageLockMode.ReadWrite, bitmapImage.PixelFormat);//System.Drawing.Imaging
            PixelFormat pixelFormat = bitmapImage.PixelFormat;//System.Drawing.Imaging
            if (pixelFormat == PixelFormat.Format32bppArgb)//System.Drawing.Imaging
            {
                stride = bitmapImage.Width * 4;
            }
            else
            {
                stride = bitmapImage.Width * 3;
            }
            Image<Bgr, byte> outputImage = new Image<Bgr, byte>(bitmapImage.Width, bitmapImage.Height, stride, bmpData.Scan0);//(IntPtr)
            //outputImage type is Emgu.CV.Image
