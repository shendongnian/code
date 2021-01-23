    public class BaseFrameMonitor
    {
        // You want to make this access thread safe
        public event EventHandler<BaseFrameEventArgs> HardwareEvent;
    
        public BaseFrameMonitor()
        {
            // Create/subscribe to your thread that
            // drains hardware signals.
        }
    }
