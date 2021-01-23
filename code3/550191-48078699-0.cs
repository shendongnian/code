    public class ChangeListCountEventArgs : EventArgs
    {
        public int NewCount
        {
            get;
            set;
        }
        public ChangeListCountEventArgs(int newCount)
        {
            NewCount = newCount;
        }
    }
