    public static class BilateralExtensionFix
    {
        public static Emgu.CV.Image<testchannels, testtype> SmoothBilateral(this Emgu.CV.Image<testchannels, testtype> image, int p1, int p2 , int p3)
        {
            var result = image.CopyBlank();
            var handle = GCHandle.Alloc(result);
            Emgu.CV.CvInvoke.cvSmooth(image.Ptr, result.Ptr, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_BILATERAL, p1, p1, p2, p3);
            handle.Free();
            return result;
        }
    }
