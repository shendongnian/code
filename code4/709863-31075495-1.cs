    class Program
        {
            static void Main(string[] args)
            {
                Image<Hsv, byte> bitmap = new Image<Hsv, byte>(@"D:\red3.bmp");
                Image<Hsv, byte> bitmap1 = new Image<Hsv, byte>(@"D:\testc.bmp");
                Image<Hsv, byte> bitmapDIFF = bitmap - bitmap1;
                Hsv lowerLimit = new Hsv(0, 0, 200);
                Hsv upperLimit = new Hsv(5, 255, 255);
    
                var imageHSVDest = bitmap.InRange(lowerLimit, upperLimit);
    
                //CvInvoke.cvShowImage("imageHSVDest", imageHSVDest);
                
               CvInvoke.cvShowImage("imageHSVDest",bitmapDIFF);
    
                bitmap.AbsDiff(bitmap1);
                CvInvoke.cvWaitKey(0);
                
            }
        }
