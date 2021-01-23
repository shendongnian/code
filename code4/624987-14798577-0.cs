    class C : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int valueOfC;
        public int ValueOfC
        {
            get { return valueOfC; }
            set
            {
                valueOfC = value;
                OnPropertyChanged(PropertyChanged);
            }
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventHandler handler)
        {
            if (handler != null)
                handler(this, new PropertyChangedEventArgs("ValueOfC"));
        }
    }
