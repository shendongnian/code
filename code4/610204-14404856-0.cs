    // The event args that has the information.
    public class BaseFrameEventArgs : EventArgs
    {
        public BaseFrameEventArgs(IBaseFrame baseFrame)
        {
            // Validate parameters.
            if (baseFrame == null) throw new ArgumentNullException("IBaseFrame");
    
            // Set values.
            BaseFrame = baseFrame;
        }
    
        // Poor man's immutability.
        public IBaseFrame BaseFrame { get; private set; }
    }
