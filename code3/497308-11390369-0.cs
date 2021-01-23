    public class ViewModel
    {
        private Timer updateTimer;
        public ViewModel()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 40;
            updateTimer.Elapsed +=new ElapsedEventHandler(updateTimer_Elapsed);
            updateTimer.Start();
        }
        private object _property;
        public object Property
        {
            get { return _property; }
            set
            {
                if (_property != value)
                {
                    _property = value;
                }
            }
        } 
        void  updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RaisePropertyChanged();
        }
    }
