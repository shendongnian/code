    class ProcessingActivatedEventArgs : EventArgs
    {
        public int MoreData { get; protected set; }
    }
    
    class Form1
    {
        private int currentData;
        public event EventHandler<ProcessingActivatedEventArgs> ProcessingActivated;
        void OnButtonClick(object sender, EventArgs args)
        {
            // ...
            if (ProcessingActivated != null)
                ProcessingActivated(new ProcessingActivatedEventArgs()
                                    {
                                        MoreData = currentData
                                    });
        }
    }
