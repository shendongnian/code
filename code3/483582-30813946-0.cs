    public class CancelableEventArgs
    {
        public bool Cancelled { get; set; }
        public void CancelFutherProcessing()
        {
            Cancelled = true;
        }
    }
