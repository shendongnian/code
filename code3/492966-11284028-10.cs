    class ProcessingActivatedEventArgs : EventArgs
    {
        public ProcessingActivatedEventArgs(int data) { MoreData = data; }
        public int MoreData { get; protected set; }
    }
    
    class Form1 : Form
    {
        private int currentData;
        public event EventHandler<ProcessingActivatedEventArgs> ProcessingActivated;
        void OnButtonClick(object sender, EventArgs args)
        {
            // ...
            if (ProcessingActivated != null)
                ProcessingActivated(new ProcessingActivatedEventArgs(currentData));
        }
    }
