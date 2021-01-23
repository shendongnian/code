    public class DictionaryEntry : INotifyPropertyChanged, IEditableObject
    {
        private string _k;
        [Description("The key")]
        public string K
        {
            [DebuggerStepThrough]
            get { return _k; }
            [DebuggerStepThrough]
            set
            {
                if (value != _k)
                {
                    _k = value;
                    OnPropertyChanged("K");
                }
            }
        }
        private string _v;
        [Description("The value")]
        public string V
        {
            [DebuggerStepThrough]
            get { return _v; }
            [DebuggerStepThrough]
            set
            {
                if (value != _v)
                {
                    _v = value;
                    OnPropertyChanged("V");
                }
            }
        }
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
        #region IEditableObject
        public void BeginEdit()
        {
            // implementation goes here
        }
        public void CancelEdit()
        {
            // implementation goes here
        }
        public void EndEdit()
        {
            // implementation goes here
        }
        #endregion
    }
