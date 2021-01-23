    public class CoupleFrames : IDisposable
            {
                public CoupleFrames(ColorImageFrame cif, Bitmap df)
                {
                    this.colorFrame = cif;
                    this.desktopFrame = df;
                }
    
                public ColorImageFrame colorFrame;
                public Bitmap desktopFrame;
    
                public void Dispose()
                {
                    this.colorFrame.Dispose();
                    this.desktopFrame.Dispose();
                }
            }
