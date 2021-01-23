    public class MyLearningEvent
    {
        public event EventHandler Closed = delegate {};
    
        public void TriggerClosed()
        {
            Closed(this, EventArgs.Empty);
        }
    }
