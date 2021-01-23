    public class CoupleFrames : IDisposable
    {
        ....
        public void Dispose()
        {
            // Your disposing code here
        }
        ~CoupleFrames()
        {
            Dispose();
        }
    }
