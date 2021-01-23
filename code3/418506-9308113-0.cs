    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int current)
        {
            this.Current = current;
        }
        public int Current { get; private set; }
    }
