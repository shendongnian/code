    public Bitmap GetPartOfTheScreen(Point location, Size size)
            {
                Bitmap screenPartCopy = new Bitmap(size.Width, size.Height);
                using (Graphics gdest = Graphics.FromImage(screenPartCopy))
                {
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, size.Width, size.Height, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                }
    
                return screenPartCopy;
            }
