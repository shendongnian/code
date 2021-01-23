    public sealed class CoupleFrames : IDisposable
    {
        private readonly ColorImageFrame colorFrame;
        private readonly Bitmap desktopFrame;
        public CoupleFrames(ColorImageFrame cif, Bitmap df)
        {
            this.colorFrame = cif;
            this.desktopFrame = df;
        }
        public void Dispose()
        {
            colorFrame.Dispose();
            desktopFrame.Dispose();
        }
    }
