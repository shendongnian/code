    public delegate void CallbackDelegate(int pos);
    [DllImport("opencv_highgui249", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cvCreateTrackbar")]
    public static extern int CvCreateTrackbar([MarshalAs(UnmanagedType.LPStr)] String trackbar_name, [MarshalAs(UnmanagedType.LPStr)] String window_name,
           [In,Out] ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)] CallbackDelegate callbackPtr);
    public static IntPtr capture = IntPtr.Zero;
    public static void myTrackbarCallback(int pos)
        {
            CvInvoke.cvSetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES, pos);
        }
    ...
    CallbackDelegate cbd = new CallbackDelegate(myTrackbarCallback);
    ...
    CvCreateTrackbar("Position", "original", ref currentPosition, frames, cbd);
