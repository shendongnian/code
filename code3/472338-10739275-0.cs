    public Form1()
    {
        InitializeComponent();
    
        //not sure if this is on initialization or in a button click event handler or wherever.
        IDevice device = new SomeDevice();
        device.StatusChanged += GetHandlerForDevice(1);
        device.DoStuff();
    
        IDevice device2 = new SomeDevice(); //could be another class that implements IDevice
        device.StatusChanged += GetHandlerForDevice(2);
        device.DoStuff();
    }
    
    /// <summary>
    /// The handlers for device status changed only vary based on the button number for each one.
    /// This method takes a button number and returns an event handler that uses that button number.
    /// </summary>
    /// <param name="buttonNumber"></param>
    /// <returns></returns>
    private EventHandler<StatusChangedEventArgs> GetHandlerForDevice(int buttonNumber)
    {
        //use currying so that the event handler which doesn't have an appropriate signature
        //can be attached to the status changed event.
        return (sender, args) => device_StatusChanged(sender, args, buttonNumber);
    }
    
    private void device_StatusChanged(object sender, StatusChangedEventArgs args, int buttonNumber)
    {
        this.Invoke((MethodInvoker)delegate
        {
            txtOutput1.Text = (args.CurrentStatus == IDevice.Status.Green ? "HIGH" : "LOW"); // runs on UI thread
    
            if (args.CurrentStatus == IDevice.Status.Green)
            {
                this.Controls["btn" + buttonNumber].BackColor = Color.Green;
            }
            else
            {
                this.Controls["btn" + buttonNumber].BackColor = Color.Red;
            }
    
    
        });
    }
    
    public interface IDevice
    {
        event EventHandler<StatusChangedEventArgs> StatusChanged;
        Status CurrentStatus { get; }
    
    
        public enum Status
        {
            Green,
            Red
        }
    
        void DoStuff();
        // rest of interface ...
    }
    
    public class StatusChangedEventArgs : EventArgs
    {
        public IDevice.Status CurrentStatus { get; set; }
        //can add additional info to pass from an IDevice to a form if needed.
    }
    
    public class SomeDevice : IDevice
    {
        public event EventHandler<StatusChangedEventArgs> StatusChanged;
    
        private IDevice.Status _currentStatus;
        /// <summary>
        /// Gets the current status of the device this object represents.
        /// When set (privately) it fires the StatusChanged event.
        /// </summary>
        public IDevice.Status CurrentStatus
        {
            get { return _currentStatus; }
            private set
            {
                _currentStatus = value;
                if (StatusChanged != null)
                {
                    StatusChangedEventArgs args = new StatusChangedEventArgs();
                    args.CurrentStatus = value;
                    StatusChanged(this, args);
                }
            }
        }
    
    
        public void DoStuff()
        {
            //... do stuff
            CurrentStatus = IDevice.Status.Green; //will fire status changed event
        }
    }
