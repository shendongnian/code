    public class CoupleFrames : IDisposable
    {
        public CoupleFrames(ColorImageFrame cif, Bitmap df)
        {
            this.colorFrame = cif;
            this.desktopFrame = df;
        }
        public ColorImageFrame colorFrame;
        public Bitmap desktopFrame;
        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this); 
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                colorFrame.Dispose();
                desktopFrame.Dispose();
            }
            disposed = true;
        }
    }
