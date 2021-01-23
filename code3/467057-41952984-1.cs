    public static Bitmap GetImage(this AForge.Math.Histogram hist) {
            var img = new Emgu.CV.Image<Gray,byte>(hist.Values.Length, 100,new Gray(255));
            for (int i = 0; i < hist.Values.Length; i++) {
                CvInvoke.Line(img, new Point(i,100), new Point(i,100 - (int)(hist.Values[i]/hist.Max)), new MCvScalar(0, 0, 0));
            }
            return img.Bitmap;}
        
