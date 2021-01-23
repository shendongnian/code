    public class TransmissionContainer : INotifyPropertyChanged
    {
        private readonly Transmission _transmission;
        public TransmissionContainer(Transmission transmission)
        {
            _transmission = transmission;
        }
        private int _id;
        public int Id
        {
            [DebuggerStepThrough]
            get { return _transmission.ID; }
            [DebuggerStepThrough]
            set
            {
                if (value != _transmission.ID)
                {
                    _transmission.ID = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public bool Cancelled
        {
            [DebuggerStepThrough]
            get { return _transmission.Cancelled }
            [DebuggerStepThrough]
            set
            {
                if (value != _transmission.Cancelled)
                {
                    _transmission.Cancelled = value;
                    OnPropertyChanged("Cancelled");
                    OnPropertyChanged("Status");
                }
            }
        }
        public string Status
        {
            [DebuggerStepThrough]
            get
            {
                StringBuilder sb = new StringBuilder("|");
                if (_transmission.Cancelled)
                    sb.Append("| Cancelled ");
                if (_transmission.Recorded)
                    sb.Append("| Recorded ");
                if (_transmission.Stored)
                    sb.Append("| Stored ");
                sb.Append("||");
                return sb.ToString();
            }
        }
        //
        // code in other properties here
        //
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
