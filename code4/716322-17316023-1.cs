    public sealed class CoupleFrames : IDisposable
    {
        private readonly ColorImageFrame colorFrame;
        private readonly Bitmap desktopFrame;
        public CoupleFrames(ColorImageFrame cif, Bitmap df)
        {
            // TODO: Argument validation, unless it's valid for these parameters
            // to be null, in which case the Dispose method would need to be careful.
            this.colorFrame = cif;
            this.desktopFrame = df;
        }
        public void Dispose()
        {
            colorFrame.Dispose();
            desktopFrame.Dispose();
        }
    }
