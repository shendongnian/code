    //is called when the worker-progress is changed
    public delegate void ProgressChangedHandler(object sender, ProgressEventArgs e);
    
    // some own EventArgs
    public class ProgressEventArgs : EventArgs
    {
        public int Percentage { get; private set; }
    
        public string Message { get; private set; }
    
        public ProgressEventArgs(int percentage, string message)
        {
            Percentage = percentage;
            Message = message;
        }
    }
