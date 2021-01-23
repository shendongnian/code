    enum ControlStatus {Idle, LoadingFile, ...}
    class StatusChangedEventArgs : EventArgs
    {
        public ControlStatus Status {get; private set;}
        public StatusChangedEventArgs(ControlStatus status)
            : base()
        {
            this.Status = status;
        }
    }
    partial class MyControl : UserControl
    {
        public ControlStatus Status {get; private set;}
        public event EventHandler<StatusChangedEventArgs> StatusChanged;
        protected virtual void OnStatusChanged(StatusChangedEventArgs e)
        {
            var hand = StatusChanged;
            if(hand != null) hand(this, e);
        }
        void LoadFiles()
        {
            ...
            Status = ControlStatus.LoadingFiles; 
            OnStatusChanged(new StatusChangedEventArgs(this.Status));
            ...
            Status = ControlStatus.Idle; 
            OnStatusChanged(new StatusChangedEventArgs(this.Status));
        }
    }
    partial class MyHostWindowsForm : Form
    {
        public MyHostWindowsForm()
        {
            var ctl = new MyControl();
            ...
            ctl.StatusChanged += ctl_StatusChanged;
        }
        void ctl_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch(e.Status)
            {
                case ControlStatus.Idle:
                    statusStripBar.Text = null;
                    break;
                case ControlStatus.LoadingFiles:
                    statusStripBar.Text = "Loading file(s)";
                    break;
                ...
            }
        }
    }
