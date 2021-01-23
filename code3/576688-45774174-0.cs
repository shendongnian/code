    static void Main(string[] args)
    {
        bool haveOpenCL = CvInvoke.HaveOpenCL;
        bool haveOpenClGpu = CvInvoke.HaveOpenCLCompatibleGpuDevice;
        CvInvoke.UseOpenCL = true;
        Emgu.CV.Image<Bgr, Byte> lenaBgr = new Image<Bgr, Byte>(@"D:\OpenCV\opencv-3.2.0\samples\data\Lena.jpg");
        CvInvoke.Imshow("Lena BSG", lenaBgr);
        Bgr color = lenaBgr[100, 100];
        Console.WriteLine("Bgr: {0}", color.ToString());
        Emgu.CV.Image<Hsv, Byte> lenaHsv = new Image<Hsv, Byte>(@"D:\OpenCV\opencv-3.2.0\samples\data\Lena.jpg");
        CvInvoke.Imshow("Lena HSV", lenaHsv);
        Hsv colorHsv = lenaHsv[100, 100];
        Console.WriteLine("HSV: {0}", colorHsv.ToString());
        CvInvoke.WaitKey(0);
    }
