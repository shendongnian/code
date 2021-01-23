    class EventWatcher
    {
        public event EventHandler<EventArrivedEventArgs> ProcessStarted;
        public ManagementEventWatcher WatchForProcessStart(string processName)
        {
            string queryString =
                "SELECT TargetInstance" +
                "  FROM __InstanceCreationEvent " +
                "WITHIN  2 " +
                " WHERE TargetInstance ISA 'Win32_Process' " +
                "   AND TargetInstance.Name = '" + processName + "'";
            // The dot in the scope means use the current machine
            string scope = @"\\.\root\CIMV2";
            // Create a watcher and listen for events
            ManagementEventWatcher watcher = new ManagementEventWatcher(scope, queryString);
            watcher.EventArrived += OnProcessStarted;
            watcher.Start();
            return watcher;
        }
        protected virtual void OnProcessStarted(object sender, EventArrivedEventArgs e)
        {
        
            EventHandler<EventArrivedEventArgs> copy = ProcessStarted;
            if (copy != null)
                copy(sender, e); // fire the event
        }
    }
    public partial class Monitor : Form
    {
        EventWatcher eventWatch = new EventWatcher();
        ManagementEventWatcher startWatcher = new ManagementEventWatcher();
        ManagementEventWatcher endWatcher = new ManagementEventWatcher();
        public Monitor()
        {
            InitializeComponent();
            startWatcher  = eventWatch.WatchForProcessStart("notepad.exe");
            startWatcher.ProcessStarted += startWatcher_ProcessStarted; // subscribe to the event
            endWatcher =   eventWatch.WatchForProcessEnd("notepad.exe");
        }
        private void startWatcher_ProcessStarted(object sender, EventArrivedEventArgs e)
        { 
            Monitor monitor = new Monitor();
            //set timer interval and start time for Monitor class. (form)
            monitor.appTimer.Interval = 5000;
            monitor.appTimer.Enabled = true;
            MessageBox.Show("notepad started");
        }
        
        private void appTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = "tick";
            MessageBox.Show("Tick");
        }
    }
