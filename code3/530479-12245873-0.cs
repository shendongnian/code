    public class ProgressEventArgs : EventArgs
    {
        public int Number { get; private set; }
        public ProgressEventArgs(int num)
        {
            this.Number = num;
        }
    }
    public class Worker
    {
        public event EventHandler<ProgressEventArgs> ProgressChanged = delegate { };
        public void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                ProgressChanged(this, new ProgressEventArgs(i));
                Thread.Sleep(1000);   //just an example here
            }
        }
    }
