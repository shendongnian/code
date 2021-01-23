    public class MSRDevice
    {
        StatusInfo _status;
        IPAD _ipad; // <-- the device
        private EventWaitHandle waitHandle = new AutoResetEvent(false);
        public MSRDevice()
        {
            //Initialize device, wire up events, etc.
        }
        public StatusInfo GetStatus()
        {
            _ipad.GetStatus() // <- raises StatusChangedEvent asynchronously
            waitHandle.WaitOne(); // <- waits for signal
            return _status;
        }
        void StateChangedEvent(object sender, DeviceStateChangeEventArgs e) 
        {
            _status = e.StatusInfo;
            waitHandle.Set(); // <- sets signal
        }
    }
