    class AppVm : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private WindowState m_state;
        public WindowState state {
            get { return m_state; }
            set { m_state=value; raise("state") }
        }
        private raise(string propname) {
            PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
        ....
    }
